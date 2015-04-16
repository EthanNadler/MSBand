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
    public class PulseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pulse
        public ActionResult Index()
        {
            return View(db.Pulses.ToList());
        }

        // GET: Pulse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pulse pulse = db.Pulses.Find(id);
            if (pulse == null)
            {
                return HttpNotFound();
            }
            return View(pulse);
        }

        // GET: Pulse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pulse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Time,BPM")] Pulse pulse)
        {
            if (ModelState.IsValid)
            {
                db.Pulses.Add(pulse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pulse);
        }

        // GET: Pulse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pulse pulse = db.Pulses.Find(id);
            if (pulse == null)
            {
                return HttpNotFound();
            }
            return View(pulse);
        }

        // POST: Pulse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Time,BPM")] Pulse pulse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pulse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pulse);
        }

        // GET: Pulse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pulse pulse = db.Pulses.Find(id);
            if (pulse == null)
            {
                return HttpNotFound();
            }
            return View(pulse);
        }

        // POST: Pulse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pulse pulse = db.Pulses.Find(id);
            db.Pulses.Remove(pulse);
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
