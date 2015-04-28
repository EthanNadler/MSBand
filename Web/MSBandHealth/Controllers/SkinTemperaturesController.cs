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
    public class SkinTemperaturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SkinTemperatures
        public ActionResult Index()
        {
            return View(db.SkinTemperatures.ToList());
        }

        // GET: SkinTemperatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkinTemperature skinTemperature = db.SkinTemperatures.Find(id);
            if (skinTemperature == null)
            {
                return HttpNotFound();
            }
            return View(skinTemperature);
        }

        // GET: SkinTemperatures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkinTemperatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Time,Temperature")] SkinTemperature skinTemperature)
        {
            if (ModelState.IsValid)
            {
                db.SkinTemperatures.Add(skinTemperature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skinTemperature);
        }

        // GET: SkinTemperatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkinTemperature skinTemperature = db.SkinTemperatures.Find(id);
            if (skinTemperature == null)
            {
                return HttpNotFound();
            }
            return View(skinTemperature);
        }

        // POST: SkinTemperatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Time,Temperature")] SkinTemperature skinTemperature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skinTemperature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skinTemperature);
        }

        // GET: SkinTemperatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkinTemperature skinTemperature = db.SkinTemperatures.Find(id);
            if (skinTemperature == null)
            {
                return HttpNotFound();
            }
            return View(skinTemperature);
        }

        // POST: SkinTemperatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SkinTemperature skinTemperature = db.SkinTemperatures.Find(id);
            db.SkinTemperatures.Remove(skinTemperature);
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
