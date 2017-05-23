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
    [Authorize]
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
            var UserId = User.Identity.GetUserId();
            var Hospital = db.Doctors.Where(i => i.USER_IDNO == UserId).Select(i => i.Hospital_ID).First();

            ViewBag.HospitalID = Hospital;
            var Blood_amount = Moto.BlodeBank(Hospital);

            ViewBag.BloodGroup_A = Blood_amount.Where(a => a.Blood_type == "A").Select(a => a.Quantity).DefaultIfEmpty().First();
            var A = Blood_amount.Where(a => a.Blood_type == "A").Select(a => a.Id).DefaultIfEmpty().First();
            ViewBag.IDA = A;
            ViewBag.BloodGroup_B = Blood_amount.Where(a => a.Blood_type == "B").Select(a => a.Quantity).DefaultIfEmpty().First();
            var B = Blood_amount.Where(a => a.Blood_type == "B").Select(a => a.Id).DefaultIfEmpty().First();
            ViewBag.IDB = B;
            ViewBag.BloodGroup_AB = Blood_amount.Where(a => a.Blood_type == "AB").Select(a => a.Quantity).DefaultIfEmpty().First();
            var AB = Blood_amount.Where(a => a.Blood_type == "AB").Select(a => a.Id).DefaultIfEmpty().First();
            ViewBag.IDAB = AB;
            ViewBag.BloodGroup_O_Negative = Blood_amount.Where(a => a.Blood_type == "O-").Select(a => a.Quantity).DefaultIfEmpty().First();
            var O_negative = Blood_amount.Where(a => a.Blood_type == "O-").Select(a => a.Id).DefaultIfEmpty().First();
            ViewBag.IDON = O_negative;
            ViewBag.BloodGroup_O_Positive = Blood_amount.Where(a => a.Blood_type == "O+").Select(a => a.Quantity).DefaultIfEmpty().First();
             var O_positive = Blood_amount.Where(a => a.Blood_type == "0+").Select(a => a.Id).DefaultIfEmpty().First();
            ViewBag.IDOP = O_positive;


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Requisition(BloodBank bloodbank)
        {
            if (ModelState.IsValid)
            {
                

                RequisitionController Moto = new RequisitionController();
                var UserId = User.Identity.GetUserId().ToString();
                var Hospital = db.Doctors.Where(i => i.USER_IDNO.ToString() == UserId).Select(i => i.Hospital_ID).First();


                var Blood_amount = Moto.BlodeBank(Hospital);
                var A = Blood_amount.Where(a => a.Blood_type == "A").Select(a => a.Quantity).DefaultIfEmpty().First();
                var B = Blood_amount.Where(a => a.Blood_type == "B").Select(a => a.Quantity).DefaultIfEmpty().First();
                var AB = Blood_amount.Where(a => a.Blood_type == "AB").Select(a => a.Quantity).DefaultIfEmpty().First();
                var O_negative = Blood_amount.Where(a => a.Blood_type == "O-").Select(a => a.Quantity).DefaultIfEmpty().First();
                var O_positive = Blood_amount.Where(a => a.Blood_type == "O+").Select(a => a.Quantity).DefaultIfEmpty().First();
                //************************************************************

                if (bloodbank.Blood_type.Equals("A"))
                {
                    var amount = bloodbank.Quantity;
                    var change = A - amount;
                    bloodbank.Quantity = change;
                }
                if (bloodbank.Blood_type.Equals("B"))
                {
                    var amount = bloodbank.Quantity;
                    var change = B - amount;
                    bloodbank.Quantity = change;
                }
                if (bloodbank.Blood_type.Equals("AB"))
                {
                    var amount = bloodbank.Quantity;
                    var change = AB - amount;
                    bloodbank.Quantity = change;
                }


                try
                {

                    // or check on FirstName and LastName if you don't have a user id
                    //var updatedUser = db.BloodBanks.SingleOrDefault(x => x.Id == A);

                    //updatedUser.Quantity = quanity.Quantity;
                    

                   
                    db.Entry(bloodbank).State = EntityState.Modified;
                        db.SaveChanges();

                    //Boolean A=true;
                    //Boolean B=true;
                    //Boolean AB=true;

                    //if(bloodbank.Blood_type.Equals("A"))
                    //{
                    //    A = false;
                       
                        
                    //}
                    //if (bloodbank.Blood_type.Equals("B"))
                    //{
                    //    B = false;
                        
                    //}
                    //if (bloodbank.Blood_type.Equals("AB"))
                    //{
                    //    AB = false;
                       
                    //}
                    //if(A==false)
                    //    ViewBag.visibleA = "none";
                    //if(B==false)
                    //    ViewBag.visibleB = "none";
                    //if(AB==false)
                    //    ViewBag.visibleAB = "none";

                    //ViewBag.Hospital_ID = new SelectList(db.Hospitals, "id", "Name");

                    return RedirectToAction("Requisition");
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",

                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        }
                    }
                

                return RedirectToAction("index","Home");
            }
            return new HttpNotFoundResult();
            
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