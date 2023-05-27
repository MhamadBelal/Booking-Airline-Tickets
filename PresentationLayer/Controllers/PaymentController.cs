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
    public class PaymentController : Controller
    {
        bool isOkay = true;
        public PaymentController()
        {
            if (!SessionHelper.IsAdmin)
            {
                isOkay = false;
            }
        }
        public ActionResult Index()
        {
            if (isOkay)
                using (MyDb d1 = new MyDb())
                {
                    var pay = d1.payments.Select(x => new UserPayment
                    {
                        cardIdPayment = x.CardId,
                        password = x.Password,
                        username = x.users.Name,
                        CardName = x.NameCard,
                        endDate = x.EndDate,
                        CVV = x.CVV,
                        money=x.Money

                    }).ToList();
                    return View(pay);
                }
            else if (SessionHelper.IsUser && !(SessionHelper.IsAdmin))
            {
                using (MyDb d1 = new MyDb())
                {
                    var pay = d1.payments.Where(x=>x.UserId==SessionHelper.UserId).Select(x => new UserPayment
                    {
                        cardIdPayment = x.CardId,
                        password = x.Password,
                        username = x.users.Name,
                        CardName = x.NameCard,
                        endDate = x.EndDate,
                        CVV = x.CVV,
                        money=x.Money

                    }).ToList();
                    return View(pay);
                }
            }
            else
                return RedirectToAction("Notfound", "Home");
        }
        public ActionResult CreatePayment()
        {
            if (SessionHelper.IsAdmin)
            {
                using (MyDb d1 = new MyDb())
                {
                    var user = d1.users.SingleOrDefault(x => x.UserId == SessionHelper.UserId);
                    ViewBag.UserName = user.Name;
                    var userName = d1.users.ToList();
                    ViewBag.User = new SelectList(userName, "UserId", "Name");
                }
                return View();
            }
            else
                return RedirectToAction("Login", "Home");
        }
        [HttpPost]
        public ActionResult CreatePayment(Payment p)
        {
            if (ModelState.IsValid)
            {
                using (MyDb d1 = new MyDb())
                {
                    if(SessionHelper.IsUser && !(isOkay))
                    p.UserId=SessionHelper.UserId;
                    d1.payments.Add(p);
                    d1.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                using (MyDb d1 = new MyDb())
                {
                    var user = d1.users.SingleOrDefault(x => x.UserId == SessionHelper.UserId);
                    ViewBag.UserName = user.Name;
                    var userName = d1.users.ToList();
                    ViewBag.User = new SelectList(userName, "UserId", "Name");
                }
            }
            return View();
          
        }
        public ActionResult EditPayment(string id)
           {
            if(isOkay)
            using (MyDb d1 = new MyDb())
            {
                if (isOkay)
                {
                    var pay = d1.payments.SingleOrDefault(x => x.CardId == id);
                    if (pay != null)
                    {
                        var userName = d1.users.ToList();
                        ViewBag.User = new SelectList(userName, "UserId", "Name");
                        return View(pay);
                    }
                }

                else if (SessionHelper.IsUser && !(isOkay))
                {
                    var pay = d1.payments.SingleOrDefault(x => x.CardId == id);
                    if (pay != null)
                    {
                        var user = d1.users.SingleOrDefault(x => x.UserId == SessionHelper.UserId);
                        ViewBag.UserName = user.Name;
                        return View(pay);
                    }
                }
            }
            return RedirectToAction("Notfound", "home");
        }
        [HttpPost]
        public ActionResult EditPayment(Payment p)
        {
            using (MyDb d1 = new MyDb())
            {
                if (ModelState.IsValid)
                {
                    if(SessionHelper.IsUser && !(isOkay)) 
                        p.UserId = SessionHelper.UserId;

                    d1.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    d1.SaveChanges();
                    return RedirectToAction("Index");
                }
                var user = d1.users.SingleOrDefault(x => x.UserId == SessionHelper.UserId);
                ViewBag.UserName = user.Name;
                var userName = d1.users.ToList();
            ViewBag.User = new SelectList(userName, "UserId", "Name");
            }
            return View(p);
        }
        [ActionName("DeletePayment")]
        public ActionResult DeleteConfirm(string id)
        {
            if(SessionHelper.IsUser)
            using(MyDb d1=new MyDb())
            {
                var p1 = d1.payments.Find(id);
                if (p1 != null)
                    return View(p1);
            }
            return RedirectToAction("Notfound","Home");
        }
        [HttpPost]
        public ActionResult DeletePayment(string id)
        {
            using(MyDb d1=new MyDb())
            {
                var p1 = d1.payments.Find(id);
                if(p1!=null)
                {
                    d1.payments.Remove(p1);
                    d1.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Notfound", "Home");
        }
    }
}