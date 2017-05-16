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
    [Authorize(Roles = "Administrator")]

    public class HospitalUsersController : Controller
    {
        private HospitalDbEntities1 db = new HospitalDbEntities1();

        // GET: HospitalUsers
        public ActionResult Index()
        {
            var hospitalUsers = db.HospitalUsers.Include(h => h.Doctor);
            return View(hospitalUsers.ToList());
        }

        // GET: HospitalUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalUser hospitalUser = db.HospitalUsers.Find(id);
            if (hospitalUser == null)
            {
                return HttpNotFound();
            }
            return View(hospitalUser);
        }

        // GET: HospitalUsers/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Doctors, "Id", "FirstName");
            return View();
        }

        // POST: HospitalUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID,Email,confirm_Email,Password")] HospitalUser hospitalUser)
        {
            if (ModelState.IsValid)
            {
                db.HospitalUsers.Add(hospitalUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Doctors, "Id", "FirstName", hospitalUser.UserID);
            return View(hospitalUser);
        }

        // GET: HospitalUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalUser hospitalUser = db.HospitalUsers.Find(id);
            if (hospitalUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Doctors, "Id", "FirstName", hospitalUser.UserID);
            return View(hospitalUser);
        }

        // POST: HospitalUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,Email,confirm_Email,Password")] HospitalUser hospitalUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospitalUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Doctors, "Id", "FirstName", hospitalUser.UserID);
            return View(hospitalUser);
        }

        // GET: HospitalUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalUser hospitalUser = db.HospitalUsers.Find(id);
            if (hospitalUser == null)
            {
                return HttpNotFound();
            }
            return View(hospitalUser);
        }

        // POST: HospitalUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HospitalUser hospitalUser = db.HospitalUsers.Find(id);
            db.HospitalUsers.Remove(hospitalUser);
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
