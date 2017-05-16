using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Link.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace Hospital_Link.Controllers
{
    [Authorize(Roles = "Administrator,manager")]
    public class RequisitionController : Controller
    {
        private HospitalDbEntities1 db = new HospitalDbEntities1();
        // GET: Requisition

       
        public IQueryable<BloodBank> BlodeBank(int? id)
        {
            RequisitionController Moto = new RequisitionController();
          

            IQueryable<BloodBank> Blood_amount = db.BloodBanks.Where(p => p.Hospital_Id == id);

            //var BloodGroup_A = Blood_amount.Where(a => a.Blood_type == "A").Count();




            return Blood_amount.AsQueryable();
        }
        public ActionResult Requisition(int? id)
        {
            RequisitionController Moto = new RequisitionController();
            var UserId = User.Identity.GetUserId().ToString();
            var Hospital = db.Doctors.Where(i => i.USER_IDNO.ToString() == UserId).Select(i => i.Hospital_ID).First();


            var Blood_amount = Moto.BlodeBank(Hospital);

            ViewBag.BloodGroup_A = Blood_amount.Where(a => a.Blood_type == "A").Select(a => a.Quantity).DefaultIfEmpty().First();
            var A = Blood_amount.Where(a => a.Blood_type == "A").Select(a => a.Id).First();
            ViewBag.BloodGroup_B = Blood_amount.Where(a => a.Blood_type == "B").Select(a => a.Quantity).DefaultIfEmpty().First();
            var B = Blood_amount.Where(a => a.Blood_type == "B").Select(a => a.Id).First();

            ViewBag.BloodGroup_AB = Blood_amount.Where(a => a.Blood_type == "AB").Select(a => a.Quantity).DefaultIfEmpty().First();
            var AB = Blood_amount.Where(a => a.Blood_type == "AB").Select(a => a.Id).First();

            ViewBag.BloodGroup_O_Negative = Blood_amount.Where(a => a.Blood_type == "O-").Select(a => a.Quantity).DefaultIfEmpty().First();
            //var O_negative = Blood_amount.Where(a => a.Blood_type == "O-").Select(a => a.Id).First();

            ViewBag.BloodGroup_O_Positive = Blood_amount.Where(a => a.Blood_type == "O+").Select(a => a.Quantity).DefaultIfEmpty().First();
           // var O_positive = Blood_amount.Where(a => a.Blood_type == "0+").Select(a => a.Id).First();



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Requisition([Bind(Include = "Quantity,Quantity,Quantity,Quantity,Quantity ")] BloodBank bloodbank)
        {
            if (ModelState.IsValid)
            {
                RequisitionController Moto = new RequisitionController();
                var UserId = User.Identity.GetUserId().ToString();
                var Hospital = db.Doctors.Where(i => i.USER_IDNO.ToString() == UserId).Select(i => i.Hospital_ID).First();


                var Blood_amount = Moto.BlodeBank(Hospital);
              
                return RedirectToAction("Requisitions");
            }
            return View();
        }
        public ActionResult Blood()
        {

            var UserId = User.Identity.GetUserId().ToString();
            var Hospital = db.Doctors.Where(i => i.USER_IDNO.ToString() == UserId).Select(i => i.Hospital_ID).First();
            var BT = db.BloodBanks.Where(h => h.Hospital_Id == Hospital);
            
            return View(BT.ToList());
        }
        

    }
}