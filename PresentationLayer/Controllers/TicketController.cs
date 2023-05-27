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
    public class TicketController : Controller
    {
        bool isOkay = true;
        public TicketController()
        {
            if (!SessionHelper.IsAdmin)
            {
                isOkay = false;
            }
        }
        public ActionResult Index()
        {
            if (SessionHelper.IsUser && !(isOkay))
            {
                using (MyDb d1 = new MyDb())
                {
                    var item = d1.tickets.Where(x=>x.UserId==SessionHelper.UserId).Select(x => new TUT
                    {
                        TicketId = x.TicketId,
                        UserName = x.users.Name,
                        TripID = x.trips.TripId,
                        Age = x.users.Age,
                        PhoneNo = x.users.PhoneNo,
                        Gender = x.users.Gender,
                        Acual_depature = x.trips.Acual_depature,
                        Acual_Arrival = x.trips.Acual_Arrival,
                        Acual_Duration = x.trips.Acual_Duration,
                        Date = x.trips.Date,
                        price = x.trips.price
                    }
                    ).ToList();
                    return View(item);
                }
            }
            else if(isOkay)
            {
                using (MyDb d1 = new MyDb())
                {
                    var item = d1.tickets.Select(x => new TUT
                    {
                        TicketId = x.TicketId,
                        UserName = x.users.Name,
                        TripID = x.trips.TripId,
                        Age = x.users.Age,
                        PhoneNo = x.users.PhoneNo,
                        Gender = x.users.Gender,
                        Acual_depature = x.trips.Acual_depature,
                        Acual_Arrival = x.trips.Acual_Arrival,
                        Acual_Duration = x.trips.Acual_Duration,
                        Date = x.trips.Date,
                        price = x.trips.price
                    }
                    ).ToList();
                    return View(item);
                }
            }
            else
                return RedirectToAction("Login", "Home");
    
        }
       
        [ActionName("DeleteTicket")]
        public ActionResult DeleteConfirm(int id)
        {
            if(SessionHelper.IsUser)
            using(MyDb d1=new MyDb())
            {
                var item = d1.tickets.Find(id);
                if (item != null)
                    return View(item);
            }
            return RedirectToAction("Notfound", "Home");
        }
        [HttpPost]
        public ActionResult DeleteTicket(int id)
        {
            using (MyDb d1 = new MyDb())
            {
                var item = d1.tickets.Find(id);
                if (item != null)
                {
                    d1.tickets.Remove(item);
                    d1.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Notfound", "Home");
            }
        }
        
    }
}