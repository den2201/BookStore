using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using store;

namespace Store.Web.Controllers
{
    public class BookController : Controller
    {
        IBookRepository Repository;

        public BookController(IBookRepository repository)
        {
            Repository = repository;
        }
        public IActionResult Index(int id)
        {
            var book = Repository.GetById(id);
            return View(book);
        }
    }
}