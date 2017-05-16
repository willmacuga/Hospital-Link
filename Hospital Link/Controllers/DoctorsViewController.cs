using Hospital_Link.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Link.Controllers
{
    [Authorize(Roles = "Administrator,Doctor,Manager")]

    public class DoctorsViewController : Controller
    {
        private HospitalDbEntities1 db = new Models.HospitalDbEntities1();

        // GET: DoctorsView
        public ActionResult Index(int? id)
        {
           
                 return View(db.DoctorsViews.ToList());



        }

        // GET: DoctorsView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Doctores_More_Details more = db.Doctores_More_Details.Find(id);
            if (more == null)
            {
                return HttpNotFound();

            }

            return View(more);
        }

        // GET: DoctorsView/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "FirstName");
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "FirstName");
            return View();
        }

        // POST: DoctorsView/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,PatientId,DoctorId,Patient_Diognosis,Current_Prescription,Previous_presciption,Date_of_Prescription")] Record record)
        {

            if (ModelState.IsValid)
            {
                db.Records.Add(record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "FirstName", record.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "FirstName", record.PatientId);
            return View(record);

        }

        // GET: DoctorsView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "FirstName", record.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "FirstName", record.PatientId);

            return View(record);
        }

        // POST: DoctorsView/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientId,DoctorId,Patient_Diognosis,Current_Prescription,Previous_presciption,Date_of_Prescription")]Record record)
        {

            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "FirstName", record.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "FirstName", record.PatientId);
            return View(record);
        }

        // GET: DoctorsView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);

        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record record = db.Records.Find(id);
            db.Records.Remove(record);
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
        
        public ActionResult search (int? id)
        {
            //var errMsg = TempData["ErrorMessage"] as string;
            if (id == null)
            {
                 new HttpNotFoundResult("Please enter Id");
               //  Response.AddHeader("REFRESH", "5;URL=Index");
               // return RedirectToAction("Index");
            }
            Doctores_More_Details SearchView = db.Doctores_More_Details.Find(id);
            if (SearchView == null)
            {
                TempData["ErrorMessage"]= "PATIENT NOT FOUND !!!"; 
                return RedirectToAction("Index");
            }
                return View(SearchView);
            


            
        }
    }
}

