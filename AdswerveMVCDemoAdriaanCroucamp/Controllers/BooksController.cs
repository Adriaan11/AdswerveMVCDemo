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
            var books = db.Books.ToList();
            return View(books);

        }

        // GET method for edit button
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // https://stackoverflow.com/questions/31287090/mvc-controller-return-a-bad-request
            }

            var book = db.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // POST method to update book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = db.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }
    }
}