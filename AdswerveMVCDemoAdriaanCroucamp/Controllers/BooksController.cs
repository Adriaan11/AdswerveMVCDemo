using AdswerveMVCDemoAdriaanCroucamp.Data;
using AdswerveMVCDemoAdriaanCroucamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}