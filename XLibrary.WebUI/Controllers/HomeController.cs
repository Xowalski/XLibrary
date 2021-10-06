using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XLibrary.Core.Contracts;
using XLibrary.Core.Models;

namespace XLibrary.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Book> context;

        public HomeController(IRepository<Book> bookContext)
        {
            context = bookContext;
        }

        public ActionResult Index()
        {
            List<Book> books = context.Collection().ToList();
            return View(books);
        }

        public ActionResult Details(string Id)
        {
            Book book = context.Find(Id);
            if (book == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(book);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}