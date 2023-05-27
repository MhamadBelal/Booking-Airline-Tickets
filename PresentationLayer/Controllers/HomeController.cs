using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineSystem;
using PresentationLayer.Models;
using PresentationLayer.Helper;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login L)
        {
            using(MyDb d1=new MyDb())
            {
                var list = d1.users.SingleOrDefault(x => x.Email == L.Email && x.Password == L.password);
                if (list != null)
                {
                    SessionHelper.Fullname = list.Name;
                    SessionHelper.IsUser = true;
                    SessionHelper.UserId = list.UserId;
                    if (list.UserRole.RoleName == "Admin")
                        SessionHelper.IsAdmin = true; 
                    return RedirectToAction("Index", "Trip");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            SessionHelper.IsUser = false;
            SessionHelper.IsAdmin = false;
            SessionHelper.Fullname = null;
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
                return View();
            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }
        public ActionResult Notfound()
        {
            return View();
        }
    }
}