using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XLibrary.Core.Contracts;
using XLibrary.Core.Models;
using XLibrary.Core.ViewModels;
using XLibrary.DataAccess.InMemory;


namespace XLibrary.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookManagerController : Controller
    {
        IRepository<Book> bookContext;
        IRepository<Reservation> reservationContext;

        public BookManagerController(IRepository<Book> BookContext, IRepository<Reservation> ReservationContext)
        {
            this.bookContext = BookContext;
            this.reservationContext = ReservationContext;
        }
        
        public ActionResult Index()
        {
            List<Book> books = bookContext.Collection().ToList();
            return View(books);
        }

        public ActionResult Create()
        {
            Book book = new Book();
            return View(book);
        }

        [HttpPost]
        public ActionResult Create(Book book, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            else
            {
                if (file != null)
                {
                    book.Image = book.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//BookImages//") + book.Image);
                }

                bookContext.Insert(book);
                bookContext.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(string Id)
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

        [HttpPost]
        public ActionResult Edit(Book book, string Id, HttpPostedFileBase file)
        {
            Book bookToEdit = bookContext.Find(Id);

            if (bookToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(book);
                }

                if (file != null)
                {
                    bookToEdit.Image = book.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//BookImages//") + bookToEdit.Image);
                }

                bookToEdit.Title = book.Title;
                bookToEdit.Author = book.Author;
                bookToEdit.Publisher = book.Publisher;
                bookToEdit.PublicationYear = book.PublicationYear;
                bookToEdit.Description = book.Description;
                bookToEdit.IsAvailable = book.IsAvailable;

                bookContext.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Book bookToDelete = bookContext.Find(Id);

            if (bookToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(bookToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Book bookToDelete = bookContext.Find(Id);

            if (bookToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                bookContext.Delete(Id);
                bookContext.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult ShowHistory(string Id)
        {
            Book book = bookContext.Find(Id);
            List<Reservation> Reservation = reservationContext.Collection().ToList();

            ShowHistoryViewModel viewmodel = new ShowHistoryViewModel();
            viewmodel.BookId = book.Id;
            viewmodel.Title = book.Title;
            viewmodel.Author = book.Author;
            viewmodel.Reservations = Reservation;


            return View(viewmodel);
        }
    }
}