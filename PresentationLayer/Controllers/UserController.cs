using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineSystem;
using PresentationLayer.Helper;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        bool isOkay = true;
        public UserController()
        {
            if (!SessionHelper.IsAdmin)
            {
                isOkay = false;
            }
        }
        public ActionResult Index()
        {
            if(SessionHelper.IsUser && !(SessionHelper.IsAdmin))
                    using (MyDb d1 = new MyDb())
                    {
                        var list = d1.users.Where(x=>x.UserId==SessionHelper.UserId).Select(x => new AdminUser
                        {
                            UserId = x.UserId,
                            Name = x.Name,
                            Password = x.Password,
                            Age = x.Age,
                            Address = x.Address,
                            Email = x.Email,
                            PhoneNo = x.PhoneNo,
                            Gender = x.Gender,
                            RoleName = x.UserRole.RoleName
                        }
                            ).ToList();
                        return View(list);
                    }
            else if(isOkay)
            {
                using (MyDb d1 = new MyDb())
                {
                    var list = d1.users.Select(x => new AdminUser
                    {
                        UserId = x.UserId,
                        Name = x.Name,
                        Password = x.Password,
                        Age = x.Age,
                        Address = x.Address,
                        Email = x.Email,
                        PhoneNo = x.PhoneNo,
                        Gender = x.Gender,
                        RoleName = x.UserRole.RoleName
                    }
                        ).ToList();
                    return View(list);
                }
            }
                    return RedirectToAction("Login", "Home");
            
        }
        public ActionResult Create()
        {
            using(MyDb d1=new MyDb())
            {
                var item = d1.roles.ToList();
                ViewBag.Role = new SelectList(item,"RoleId","RoleName");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if(!SessionHelper.IsAdmin)
            user.RoleId = 2;
            if (ModelState.IsValid)
            {
                using (MyDb d1 = new MyDb())
                { 
                    
                    if (!(d1.users.Any(x => x.Email == user.Email)))
                    {
                        d1.users.Add(user);
                        d1.SaveChanges();
                        if(SessionHelper.IsAdmin)
                        return RedirectToAction("Index", "User");
                        else
                        {
                            SessionHelper.Fullname = user.Name;
                            SessionHelper.IsUser = true;
                            SessionHelper.UserId = user.UserId;
                            return RedirectToAction("Index", "Trip");
                        }
                    }
                    else
                        ViewBag.Found = "This email is already found";
                }
            }
            else
                {
                    using (MyDb d1 = new MyDb())
                    {
                        var item = d1.roles.ToList();
                        ViewBag.Role = new SelectList(item, "RoleId", "RoleName");
                    }
                }
            return View();
        }






        public ActionResult Edit(int id)
        {
            if (SessionHelper.IsUser)

                using (MyDb d1 = new MyDb())
                {
                    var u1 = d1.users.SingleOrDefault(x => x.UserId == id);
                    if (u1 != null)
                    {
                        var item = d1.roles.ToList();
                        ViewBag.Role = new SelectList(item, "RoleId", "RoleName");
                        return View(u1);
                    }
                    return RedirectToAction("Notfound", "Home");
                }
            return RedirectToAction("Notfound", "Home");
        }

        [HttpPost]
        public ActionResult Edit(User m)
        {
            using (MyDb d1 = new MyDb()) { 
                if (ModelState.IsValid)
                {
                    
                        d1.Entry(m).State = System.Data.Entity.EntityState.Modified;
                        d1.SaveChanges();
                    SessionHelper.Fullname = m.Name;
                    return RedirectToAction("Index");
                    
                }
                var item = d1.roles.ToList();
                ViewBag.Role = new SelectList(item, "RoleId", "RoleName");
            }
            return View(m);
                    
        }
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            if (isOkay)
                using (MyDb d1 = new MyDb())
                {
                    var u1 = d1.users.Find(id);
                    if (u1 != null)
                    {
                        return View(u1);
                    }
                }
            return RedirectToAction("Notfound", "Home");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
                using (MyDb d1 = new MyDb())
                {
                    var u1 = d1.users.Find(id);
                    if (u1 != null)
                    {
                        d1.users.Remove(u1);
                        d1.SaveChanges();
                        return RedirectToAction("Index");

                    }
                }
            return RedirectToAction("Notfound", "Home");
        }

    }
}
    