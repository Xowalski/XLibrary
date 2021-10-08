using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XLibrary.Core.Contracts;
using XLibrary.Core.Models;
using XLibrary.DataAccess.InMemory;


namespace XLibrary.WebUI.Controllers
{
    public class BookManagerController : Controller
    {
        IRepository<Book> context;

        public BookManagerController(IRepository<Book> bookContext)
        {
            context = bookContext;
        }
        
        public ActionResult Index()
        {
            List<Book> books = context.Collection().ToList();
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

                context.Insert(book);
                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(string Id)
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

        [HttpPost]
        public ActionResult Edit(Book book, string Id, HttpPostedFileBase file)
        {
            Book bookToEdit = context.Find(Id);

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

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Book bookToDelete = context.Find(Id);

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
            Book bookToDelete = context.Find(Id);

            if (bookToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}