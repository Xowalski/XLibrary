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
        IRepository<Book> bookContext;
        IRepository<Reader> readers;
        IReserveService reserveService;

        public HomeController(IRepository<Book> BookContext, IRepository<Reader> Readers, IReserveService ReserveService)
        {
            this.bookContext = BookContext;
            this.readers = Readers;
            this.reserveService = ReserveService;
        }

        public ActionResult Index()
        {
            List<Book> books = bookContext.Collection().ToList();
            return View(books);
        }

        public ActionResult Details(string Id)
        {
            Book book = bookContext.Find(Id);
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

        [Authorize]
        public ActionResult ReserveAction(string Id)
        {
            Reader reader = readers.Collection().FirstOrDefault(r => r.Email == User.Identity.Name);
            Book book = bookContext.Find(Id);

            if (reader != null)
            {
                Reservation reservation = new Reservation()
                {
                    ReservedBookId = book.Id,
                    ReaderId = reader.Id
                };
                reserveService.CreateReservation(reservation);
                book.IsAvailable = false;
                bookContext.Commit();
                return RedirectToAction("Thankyou", new { BookTitle = book.Title });
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
        }

        public ActionResult ThankYou(string BookTitle)
        {
            ViewBag.BookTitle = BookTitle;
            return View();
        }
    }
}