using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital_Link.Models;

namespace Hospital_Link.Controllers
{
    [Authorize(Roles = "Administrator, Manager ")]

    public class ChemistsController : Controller
    {
        private HospitalDbEntities1 db = new HospitalDbEntities1();

        // GET: Chemists
        public ActionResult Index()
        {
            return View(db.Chemists.ToList());
        }

        // GET: Chemists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chemist chemist = db.Chemists.Find(id);
            if (chemist == null)
            {
                return HttpNotFound();
            }
            return View(chemist);
        }

        // GET: Chemists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chemists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Location,Geocoordinates,Attendant,Clearance")] Chemist chemist)
        {
            if (ModelState.IsValid)
            {
                db.Chemists.Add(chemist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chemist);
        }

        // GET: Chemists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chemist chemist = db.Chemists.Find(id);
            if (chemist == null)
            {
                return HttpNotFound();
            }
            return View(chemist);
        }

        // POST: Chemists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location,Geocoordinates,Attendant,Clearance")] Chemist chemist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chemist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chemist);
        }

        // GET: Chemists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chemist chemist = db.Chemists.Find(id);
            if (chemist == null)
            {
                return HttpNotFound();
            }
            return View(chemist);
        }

        // POST: Chemists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chemist chemist = db.Chemists.Find(id);
            db.Chemists.Remove(chemist);
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
