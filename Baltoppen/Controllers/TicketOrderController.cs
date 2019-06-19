using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Baltoppen.Models;

namespace Baltoppen.Controllers
{
    public class ScreeningsController : Controller
    {
        private BaltoppenEntities1 db = new BaltoppenEntities1();

        // GET: Screenings
        public ActionResult Index()
        {
            return View(db.Screenings.ToList());
        }

        // GET: Screenings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screenings screenings = db.Screenings.Find(id);
            if (screenings == null)
            {
                return HttpNotFound();
            }
            return View(screenings);
        }

        // GET: Screenings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Screenings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScreeningId,ScreeningStart,FkMovieId,FkTheaterId")] Screenings screenings)
        {
            if (ModelState.IsValid)
            {
                db.Screenings.Add(screenings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(screenings);
        }

        // GET: Screenings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screenings screenings = db.Screenings.Find(id);
            if (screenings == null)
            {
                return HttpNotFound();
            }
            return View(screenings);
        }

        // POST: Screenings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScreeningId,ScreeningStart,FkMovieId,FkTheaterId")] Screenings screenings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(screenings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(screenings);
        }

        // GET: Screenings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screenings screenings = db.Screenings.Find(id);
            if (screenings == null)
            {
                return HttpNotFound();
            }
            return View(screenings);
        }

        // POST: Screenings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Screenings screenings = db.Screenings.Find(id);
            db.Screenings.Remove(screenings);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
