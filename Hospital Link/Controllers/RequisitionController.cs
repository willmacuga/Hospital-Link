using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Link.Models;
using Microsoft.AspNet.Identity;


namespace Hospital_Link.Controllers
{
    public class RequisitionController : Controller
    {
        private HospitalDbEntities1 db = new HospitalDbEntities1();
        // GET: Requisition
        public ActionResult Index()
        {
           var UserId= User.Identity.GetUserId();

            return View();
        }
        
    }
}