using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using store;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBookRepositoty bookRepository;

        public SearchController(IBookRepositoty repositoty)
        {
            bookRepository = repositoty;
        }

        public IActionResult Index(string query)
        {
            var books = bookRepository.GetAllByTitle(query);
            return View(books);
        }
    }
}