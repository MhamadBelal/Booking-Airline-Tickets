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
    public class TripController : Controller
    {
        bool isOkay = true;
        public TripController()
        {
            if (!SessionHelper.IsAdmin)
            {
                isOkay = false;
            }
        }
        public ActionResult Index()
        {
            if(SessionHelper.IsUser)
            {
                using (MyDb d1 = new MyDb())
                {
                    var item = d1.trips.Select(x => new TripAndSced
                    {
                        TripId = x.TripId,
                        PlaceFrom = x.Sced.PlaceFrom,
                        placeTo = x.Sced.PlaceTo,
                        AvaliableSets = x.Avaliable,
                        Acual_depature = x.Acual_depature,
                        Acual_Arrival = x.Acual_Arrival,
                        Acual_Duration = x.Acual_Duration,
                        DateTrip = x.Date,
                        priceTrip = x.price,
                        TripName = x.Sced.TripName


                    }).ToList();
                    return View(item);
                }
            }
            else
                return RedirectToAction("Login", "Home");
        }
        public ActionResult CreateTrip()
        {
            if(isOkay)
            {
                using (MyDb d1 = new MyDb())
                {
                    var item = d1.ScheduleTrips.ToList();
                    ViewBag.trips = new SelectList(item, "TripName", "TripName");
                }
                return View();
            }
            return RedirectToAction("Notfound", "Home");
        }
        [HttpPost]
        public ActionResult CreateTrip(Trip t)
        {
            if(ModelState.IsValid)
            {
                using (MyDb d1 = new MyDb())
                {
                    d1.trips.Add(t);
                    d1.SaveChanges();
                    return RedirectToAction("Index");
                }
            } 
            else
            {
                using (MyDb d1 = new MyDb())
                {
                    var item = d1.ScheduleTrips.ToList();
                    ViewBag.trips = new SelectList(item, "TripName", "TripName");
                }
            }
            return View();
        }

        public ActionResult EidtTrip(string id)
        {
            if(isOkay)
            using (MyDb d1 = new MyDb())
            {
                var item = d1.trips.SingleOrDefault(x => x.TripId == id);
                if (item != null)
                {
                    var it = d1.ScheduleTrips.ToList();
                    ViewBag.trips = new SelectList(it, "TripName", "TripName");
                    return View(item);
                }
            }
            return RedirectToAction("Notfound", "Home");
        }
        [HttpPost]
        public ActionResult EidtTrip(Trip t)
        {
            using (MyDb d1 = new MyDb())
            {
                if (ModelState.IsValid)
                {
                    d1.Entry(t).State = System.Data.Entity.EntityState.Modified;
                    d1.SaveChanges();
                    return RedirectToAction("Index");
                }
                var it = d1.ScheduleTrips.ToList();
                ViewBag.trips = new SelectList(it, "TripName", "TripName");
            }
            return View(t);
        }
        [ActionName("DeleteTrip")]
        public ActionResult DeleteConfirm(string id)
        {
            if(isOkay)
            using(MyDb d1=new MyDb())
            {
                var item = d1.trips.Find(id);
                if (item != null)
                    return View(item);
            }
            return RedirectToAction("Notfound", "Home");
        }
        [HttpPost]
        public ActionResult DeleteTrip(string id)
        {
            using (MyDb d1 = new MyDb())
            {
                var item = d1.trips.Find(id);
                if (item != null)
                {
                    d1.trips.Remove(item);
                    d1.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return RedirectToAction("Notfound", "Home");

            }
        }







        public ActionResult BuyTicket(string id)
        {
            if (SessionHelper.IsUser)
            {
                using (MyDb d1 = new MyDb())
                {
                    var t1 = d1.trips.SingleOrDefault(x => x.TripId == id);
                    if(t1!=null)
                    return View(t1);
                }
            }
                return RedirectToAction("Login","Home");
            
        }




        [HttpPost]
        public ActionResult BuyTicket(Trip trip)
        {
            using (MyDb d1 = new MyDb())
            {
                    Ticket _ticket = new Ticket();
                    _ticket.TripId = trip.TripId;
                        _ticket.UserId = SessionHelper.UserId;
                    d1.tickets.Add(_ticket);
                    d1.SaveChanges();

                    return RedirectToAction("Index", "Ticket");
            }    
        }

    }
}