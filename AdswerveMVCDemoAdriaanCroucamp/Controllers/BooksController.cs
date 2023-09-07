using AdswerveMVCDemoAdriaanCroucamp.Data;
using AdswerveMVCDemoAdriaanCroucamp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdswerveMVCDemoAdriaanCroucamp.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET method for list/index
        public ActionResult Index()
        {
            // Retrieve a list of books from the database
            var books = db.Books.ToList();
            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                // Return a 400 Bad Request if 'id' is not provided
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // https://stackoverflow.com/questions/31287090/mvc-controller-return-a-bad-request
            }

            // Find the book with the given 'id' in the database
            var book = db.Books.Find(id);

            if (book == null)
            {
                // Return a 404 Not Found if the book with 'id' doesn't exist
                return HttpNotFound();
            }

            // Display details of the book
            return View(book);
        }

        // GET method for the edit page
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                // Return a 400 Bad Request if 'id' is not provided
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Find the book with the given 'id' in the database
            var book = db.Books.Find(id);

            if (book == null)
            {
                // Return a 404 Not Found if the book with 'id' doesn't exist
                return HttpNotFound();
            }

            // Display the book for editing
            return View(book);
        }

        // POST method to update book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                // Update the book's information in the database
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();

                // Redirect to the details page of the edited book
                return RedirectToAction("Details", new { id = book.Book_Id });
            }

            // If there are validation errors, return to the edit page with error messages
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                // Return a 400 Bad Request if 'id' is not provided
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Find the book with the given 'id' in the database
            var book = db.Books.Find(id);

            if (book == null)
            {
                // Return a 404 Not Found if the book with 'id' doesn't exist
                return HttpNotFound();
            }

            // Display the book for deletion confirmation
            return View(book);
        }

        // POST method to confirm book deletion
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Find the book with the given 'id' in the database
            var book = db.Books.Find(id);

            // Remove the book from the database
            db.Books.Remove(book);
            db.SaveChanges();

            // Redirect to the book list after successful deletion
            return RedirectToAction("Index");
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            // Display the page to create a new book
            return View();
        }

        // POST method to create a new book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                // Add the new book to the database
                db.Books.Add(book);
                db.SaveChanges();

                // Redirect to the book list after successful creation
                return RedirectToAction("Index");
            }

            // If there are validation errors, return to the create page with error messages
            return View(book);
        }
    }
}
