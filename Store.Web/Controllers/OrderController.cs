using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store.Contractors;
using store;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IEnumerable<IDeliveryService> deliveryServices;

        public OrderController(IBookRepository repository,
                                            IOrderRepository orderRepository,
                                            IEnumerable<IDeliveryService> services)
        {
            bookRepository = repository;
            this.orderRepository = orderRepository;
            deliveryServices = services;
        }

        public OrderModel Map(Order order)
        {
            var bookId = order.Items.Select(item => item.BookId);
            var books = bookRepository.GetAllBooksById(bookId);

            var itemModel = from item in order.Items
                            join book in books on item.BookId equals book.Id
                            select new OrderItemModel
                            {
                                BookId = book.Id,
                                Title = book.Title,
                                Author = book.Author,
                                Price = item.Price,
                                Count = item.Count
                            };

            return new OrderModel
            {
                Id = order.Id,
                State = order.State,
                orderItems = itemModel.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice

            };
        }
        
        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
              var order = orderRepository.GetById(cart.OrderId);
                OrderModel model = Map(order);
                return View(model);
            }
            return View("Empty");
        }

        [HttpPost]
        public IActionResult AddItem(int id)
        {
            Cart cart;
            Order order;
            if(HttpContext.Session.TryGetCart(out cart))
            {
                order = orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }

            var book = bookRepository.GetById(id);
            order.AddItem(book, 1);
            orderRepository.Update(order);
            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;

            HttpContext.Session.Set(cart);
            return RedirectToAction("Index", "Book", new { id });
        }

        [HttpPost]

        public IActionResult RemoveItem(int Id)
        {
            Cart cart;
            Order order;
            if (HttpContext.Session.TryGetCart(out cart))
            {
                order = orderRepository.GetById(cart.OrderId);
            }
            else
            {
                throw new Exception("Cart not found");
            }

            var book = bookRepository.GetById(Id);
            order.RemoveItem(book);

            return null;
        }

        [HttpPost]

        public IActionResult SendConfirmationCode(int id,string cellPhone)
        {
            var order = orderRepository.GetById(id);
            var model = Map(order);

            if (!IsValidatePhone(cellPhone))
            {
                model.Errors["cellPhone"] = "Telephone number is not correct";
                return View("Index", model);
            }

            int code = 1111; //Random.Next(1000,1000);
            HttpContext.Session.SetInt32(cellPhone, code);
           // notificationService.SendConfirmationCode(cellPhone, code);
            return View("Confirmation",
                new ConfirmationModel { OrderId = id,CellPhone = cellPhone});
            
        }

        private bool IsValidatePhone(string cellPhone)
        {
            if(cellPhone == null)
            {
                return false;
            }
            cellPhone = cellPhone.Replace(" ", "")
                                 .Replace("-", "");
            return Regex.IsMatch(cellPhone, @"^\+?\d{11}$");
        }

        [HttpPost]

        public IActionResult Confirmate(int id, string cellPhone, int code)
        {
            int? storeCode = HttpContext.Session.GetInt32(cellPhone);
            if (storeCode == null)
            {
                return View("Confirmate",

                    new ConfirmationModel
                    {
                        OrderId = id,
                        CellPhone = cellPhone,
                        Errors = new Dictionary<string, string>
                        {
                            {"code" , "Code cant be empty" }
                        }
                    });
            }

            if(storeCode != code)
            {
                return View("Confirmate",

                   new ConfirmationModel
                   {
                       OrderId = id,
                       CellPhone = cellPhone,
                       Errors = new Dictionary<string, string>
                       {
                            {"code" , "Incorrect code" }
                       }
                   });
            }

            // Save CellPhone number;

            HttpContext.Session.Remove(cellPhone);

            var model = new DeliveryModels
            {
                OrderId = id,
                Methods =
                deliveryServices.ToDictionary(service => service.UniqueCode,
                                                       service => service.Title)
            };

            return View("DliveryMethod", model);

        }

        [HttpPost]

        public IActionResult StartDelivery(int id, string uniqueCode)
        {
            var deliveryService = deliveryServices.Single(service => service.UniqueCode == uniqueCode);
            var order = orderRepository.GetById(id);

            var form = deliveryService.CreateForm(order);
            return View("DeliveryStep",form);
        }

        [HttpPost]

        public IActionResult NextDelivery(int id, string uniqueCode, int step, Dictionary<string, string> values)
        {
            var service = deliveryServices.Single(x => x.UniqueCode == uniqueCode);
            var form = service.MoveNext(id, step, values);

            if(form.IsFinal)
            {
                return null;
            }
            return View("DeliveryStep", form);

        }
      
    }
}