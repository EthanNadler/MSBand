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
    public class ActivityLevelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ActivityLevels
        public ActionResult Index()
        {
            return View(db.ActivityLevels.ToList());
        }

        // GET: ActivityLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityLevel activityLevel = db.ActivityLevels.Find(id);
            if (activityLevel == null)
            {
                return HttpNotFound();
            }
            return View(activityLevel);
        }

        // GET: ActivityLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActivityLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Time,Level")] ActivityLevel activityLevel)
        {
            if (ModelState.IsValid)
            {
                db.ActivityLevels.Add(activityLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activityLevel);
        }

        // GET: ActivityLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityLevel activityLevel = db.ActivityLevels.Find(id);
            if (activityLevel == null)
            {
                return HttpNotFound();
            }
            return View(activityLevel);
        }

        // POST: ActivityLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Time,Level")] ActivityLevel activityLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activityLevel);
        }

        // GET: ActivityLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityLevel activityLevel = db.ActivityLevels.Find(id);
            if (activityLevel == null)
            {
                return HttpNotFound();
            }
            return View(activityLevel);
        }

        // POST: ActivityLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityLevel activityLevel = db.ActivityLevels.Find(id);
            db.ActivityLevels.Remove(activityLevel);
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
