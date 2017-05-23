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
    [Authorize(Roles ="Administrator,ChemistRole,Manager")]
    public class ChemistViewController : Controller
    {
        private HospitalDbEntities1 db = new HospitalDbEntities1();
        // GET: ChemistView
        public ActionResult Index()
        {
            
            return View(db.ChemistViews.ToList());
        }

        // GET: ChemistView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChemistView details = db.ChemistViews.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

       
        
        // GET: ChemistView/Edit/5
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

        // POST: ChemistView/Edit/5
        [HttpPost]
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

        // GET: ChemistView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChemistView/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult search(int? id)
        {
            if (id == null)
            {
                new HttpNotFoundResult("Enter Id");
            }
            ChemistView patientInfo = db.ChemistViews.Find(id);
            if (patientInfo == null)
            {
                TempData["ErrorMessage"] = "PATIENT NOT FOUND";
                return RedirectToAction("Index");
            }

            return View(patientInfo);
        }
    }
}
