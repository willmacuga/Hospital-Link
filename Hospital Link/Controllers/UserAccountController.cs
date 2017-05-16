﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Link.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace Hospital_Link.Controllers
{
    public class UserAccountController : Controller
    {
        HospitalDbEntities1 db = new HospitalDbEntities1();

        // GET: UserAccount
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Regester()
        {
            

                //ViewBag.UserID = new SelectList(db.Doctors, "Id", "Id");
            ViewBag.Hospital_ID = new SelectList(db.Hospitals, "id", "Name");


            return View();
        }
        [HttpPost]
        public ActionResult Regester([Bind(Include = "Id,FirstName,SurName,Practice,Room_NO,Contact,Email,Hospital_ID,USER_IDNO")]Doctor user)
        {
            //VerifyID(user.UserID);

                if (ModelState.IsValid) {

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
              




                ViewBag.Hospital_ID = new SelectList(db.Hospitals, "id", "Name");
                return RedirectToAction("Index");
            }


            return View();
        }
        public ActionResult VerifyID(int? id)
        {
            if (id == null)
            {
                new HttpNotFoundResult("Enter Id");
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                TempData["ErrorMessage1"] = "DOCTOR NOT FOUND";

            }

            ViewBag.Hospital_ID = new SelectList(db.Hospitals, "id", "Name");
            ViewBag.UserID = User.Identity.GetUserId();
           // ViewBag.Name = isvalid.SurName.ToString();

            return View("Regester",doctor);

        }
        //[HttpPost]
        //public ActionResult VerifyID( Doctor doctor)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        db.Doctors.Add(doctor);
        //        db.SaveChanges();

        //    }


        //    ViewBag.UserID = new SelectList(db.Doctors, "Id", "Id");
        //    ViewBag.Hospital_ID = new SelectList(db.Hospitals, "id", "Name");

        //    return View();
        //}

        public ActionResult Login()
        {
            ViewBag.UserID = new SelectList(db.Doctors, "Id", "Id");

            return View();

        }
        [HttpPost]
        public ActionResult Login(HospitalUser user)
        {

            if (ModelState.IsValid)
            {

                int UserId = user.UserID;
                ViewBag.UserID = new SelectList(db.Doctors, "Id", "FirstName", user.UserID);

                string password = user.Password.ToString();
                string userName = user.Doctor.FirstName.ToString();
               
                bool userValid = db.HospitalUsers.Any(u => u.UserID == UserId && u.Password == password);

                if (userValid)
                {
                    FormsAuthentication.SetAuthCookie(userName, false);
                    

                    return RedirectToAction("loggedin");
                }
            }

            else
            {
                 ModelState.AddModelError(" ", "ID and Password combination Error");
            }
            return View();

        }
        public ActionResult loggedin()
        {
            if (Session["UserID"] != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }
    }
}