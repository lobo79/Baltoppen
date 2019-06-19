using Baltoppen.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baltoppen.Controllers
{
    public class HomeController : Controller
    {
        // private BaltoppenEntities db = new BaltoppenEntities();
        private BaltoppenEntities1 db = new BaltoppenEntities1();

        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        

        public ActionResult ComingMovies()
        {
            ViewBag.Message = "Kommende film.";

            return View();
        }

        public ActionResult BuyGiftcard()
        {
            ViewBag.Message = "Køb et gavekort.";

            return View();
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