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
    [Authorize(Roles = "Administrator,manager")]
    

    public class HospitalsController : Controller
    {
        private HospitalDbEntities1 db = new HospitalDbEntities1();
       

        // GET: Hospitals
        public ActionResult Index()
        {
            return View(db.Hospitals.ToList());
        }

        // GET: Hospitals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        // GET: Hospitals/Create
        public ActionResult Create()
        {
        
            ViewBag.Attendant = new SelectList(db.Doctors, "Id", "FirstName");
            ViewBag.Hospital_ID = new SelectList(db.Hospitals, "id", "Name");


            return View();
        }

        // POST: Hospitals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Location,Latitude,Longitude,Attendant")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
               
                db.Hospitals.Add(hospital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Attendant = new SelectList(db.Doctors, "Id", "FirstName", hospital.Attendant);
            ViewBag.Hospital_ID = new SelectList(db.Hospitals, "id", "Name");


            return View(hospital);
        }

        // GET: Hospitals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            ViewBag.Attendant = new SelectList(db.Doctors, "Id", "FirstName", hospital.Attendant);

            return View(hospital);
        }

        // POST: Hospitals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location,Latitude,Longitude,Attendant")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Attendant = new SelectList(db.Doctors, "Id", "FirstName", hospital.Attendant);

            return View(hospital);
        }

        // GET: Hospitals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospital hospital = db.Hospitals.Find(id);
            db.Hospitals.Remove(hospital);
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
        public IQueryable<BloodBank> BlodeBank(int? id)
        {
            IQueryable<BloodBank> Blood_amount=db.BloodBanks.Where(p => p.Hospital_Id == id);

            //var BloodGroup_A = Blood_amount.Where(a => a.Blood_type == "A").Count();




            return Blood_amount.AsQueryable();
        }
            
        public ActionResult Location(double? lat ,double? lon,int?id)
        {
            HospitalsController Moto = new HospitalsController();

           var Blood_amount= Moto.BlodeBank(id);
            //  var BloodGroup_A = Blood_amount.Equals("A");



            if (lat ==null || lon == null)
            {

            }
       //Location Viewbags
                ViewBag.lat = lat;
                ViewBag.lon = lon;
            //Drs  & Patients Viewbags
            var Dr_No = db.Doctors.Where(d => d.Hospital_ID == id).Count();  
            ViewBag.DR_NO = Dr_No;

            ViewBag.P_No = db.Records.Where(p => p.Hospital_ID == id).Count();
            //Blood Group View bags
            ViewBag.BloodGroup_A = Moto.BlodeBank(id).Where(a => a.Blood_type == "A").Count();
            ViewBag.BloodGroup_B = Blood_amount.Where(a => a.Blood_type == "B").Count();
            ViewBag.BloodGroup_AB = Blood_amount.Where(a => a.Blood_type == "AB").Count();
            ViewBag.BloodGroup_O_Negative = Blood_amount.Where(a => a.Blood_type == "O_").Count();
            ViewBag.BloodGroup_O_Positive = Blood_amount.Where(a => a.Blood_type == "O+").Count();
            //Blood Group View bags

            return View();
        }
        public ActionResult blood(BloodBank bloodbank)
        {
            if(ModelState.IsValid)
            {
                db.BloodBanks.Add(bloodbank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
         

            ViewBag.Hospital_ID = new SelectList(db.Hospitals, "id", "Name", bloodbank.Hospital_Id);
            return View();

        }
    }
    //public class AccessDeniedAuthorizeAttribute : AuthorizeAttribute
    //{
    //    public override void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        base.OnAuthorization(filterContext);

    //        if (filterContext.Result is HttpUnauthorizedResult)
    //        {
               
    //            filterContext.Result = new RedirectResult("~/Account/Login");
    //        }
    //    }
       

    
   
}
