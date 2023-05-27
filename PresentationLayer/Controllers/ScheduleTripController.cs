using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineSystem;
using PresentationLayer.Helper;

namespace PresentationLayer.Controllers
{
    public class ScheduleTripController : Controller
    {
        bool isOkay = true;
        public ScheduleTripController()
        {
            if (!SessionHelper.IsAdmin)
            {
                isOkay = false;
            }
        }
        public ActionResult Index()
        {
           if(isOkay)
            using(MyDb d1=new MyDb())
            {
                var item = d1.ScheduleTrips.ToList();
                return View(item);
            }
            return RedirectToAction("Notfound", "Home");
        }
        public ActionResult CreateScheduleTrip()
        { 
            if(isOkay)
            return View();
            return RedirectToAction("Notfound", "Home");
        }
        [HttpPost]
        public ActionResult CreateScheduleTrip(ScheduleTrip s1)
        {
            using(MyDb d1=new MyDb())
            {
                if(ModelState.IsValid)
                {
                    if (!(d1.ScheduleTrips.Any(x => x.TripName == s1.TripName)))
                    {
                        d1.ScheduleTrips.Add(s1);
                        d1.SaveChanges();
                        return RedirectToAction("index");
                    }
                }
                return View();
            }  
        }
        public ActionResult EidtScheduleTrip(string id)
        {
            if(isOkay)
            using(MyDb d1=new MyDb())
            {
                var item = d1.ScheduleTrips.SingleOrDefault(x => x.TripName == id);
                if (item != null)
                    return View(item);
            }
            return RedirectToAction("Notfound", "Home");
        }
        [HttpPost]
        public ActionResult EidtScheduleTrip(ScheduleTrip s1)
        {
            using(MyDb d1=new MyDb())
            {
                if (ModelState.IsValid)
                {
                    d1.Entry(s1).State = System.Data.Entity.EntityState.Modified;
                    d1.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(s1);
        }
        [ActionName("DeleteScheduleTrip")]
        public ActionResult DeleteConfirm(string id)
        {
            if(isOkay)
            using(MyDb d1=new MyDb())
            {
                var item = d1.ScheduleTrips.Find(id);
                if (item != null)
                    return View(item);
            }
            return RedirectToAction("Notfound", "Home");
        }
        [HttpPost]
        public ActionResult DeleteScheduleTrip(string id)
        {
            using(MyDb d1=new MyDb())
            {
                var item = d1.ScheduleTrips.Find(id);
                if(item!=null)
                {
                    d1.ScheduleTrips.Remove(item);
                    d1.SaveChanges();
                    return RedirectToAction("Index");
                }  
            }
            return RedirectToAction("Notfound","Home");
        }
    }
}