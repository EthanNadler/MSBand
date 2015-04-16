using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSBandHealth.Models;

namespace MSBandHealth.Controllers
{
    public class DistancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Distances
        public ActionResult Index()
        {
            return View(db.Distances.ToList());
        }

        // GET: Distances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distance distance = db.Distances.Find(id);
            if (distance == null)
            {
                return HttpNotFound();
            }
            return View(distance);
        }

        // GET: Distances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Time,Length")] Distance distance)
        {
            if (ModelState.IsValid)
            {
                db.Distances.Add(distance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distance);
        }

        // GET: Distances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distance distance = db.Distances.Find(id);
            if (distance == null)
            {
                return HttpNotFound();
            }
            return View(distance);
        }

        // POST: Distances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Time,Length")] Distance distance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distance);
        }

        // GET: Distances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distance distance = db.Distances.Find(id);
            if (distance == null)
            {
                return HttpNotFound();
            }
            return View(distance);
        }

        // POST: Distances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distance distance = db.Distances.Find(id);
            db.Distances.Remove(distance);
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
