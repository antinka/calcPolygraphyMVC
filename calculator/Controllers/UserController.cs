using calculator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace calculator.Controllers
{
    public class UserController : Controller
    {
        poligraphContext db = new poligraphContext();
      
        //Registration Action
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        //Registration POST action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                var ifExistUserName = (from b in db.Users where b.UserName == user.UserName select b).Count();
                if (ifExistUserName == 0)
                { 
                db.Users.Add(user);
                db.SaveChanges();
                var details = db.Users.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                Session["user"] = new User { UserId = details.UserId, UserName = details.UserName.ToString() };
                Session["UserId"] = details.UserId.ToString();
                Session["UserName"] = details.UserName.ToString();
                    return RedirectToAction("Welcom");
                }
                ModelState.AddModelError("", "Такой логин уже существует");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        int id=0 ;
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {
                var details = db.Users.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                int IsAdm = 0;
                if (details != null)
                {
                    Session["user"] = new User { UserId = details.UserId, UserName = details.UserName.ToString() };
                    Session["UserId"] = details.UserId.ToString();
                    Session["UserName"] = details.UserName.ToString();
                   
                    var takeRole = from r in db.Users where r.UserName == details.UserName select r.IsAdmin;
                    foreach (var w in takeRole)
                    {
                        if (w == 1)
                        {
                            Session["adm"] = new User { UserId = details.UserId, UserName = details.UserName.ToString() };
                  
                        }
                    }
                     ViewBag.IsAdm=IsAdm;
                    return RedirectToAction("Welcom");
                }
}
            catch (Exception ex)
            {
                    ModelState.AddModelError("", "Ошибка входа");
                }
                 
                return View(user);
            
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Welcom");

        }
         public ActionResult Welcom()
        {
            return View();
        }
         [HttpGet]
         public ActionResult EditMyself()
         {

             var w = Session["UserId"];
             id = Int32.Parse((string)w);
             if (id != 0)
             {
                 User user = db.Users.Find(id);
                 if (user != null)
                 {
                     return View(user);
                 }
             } 
             return HttpNotFound();
             
            
         }
         [HttpPost]
         public ActionResult EditMyself(User user)
         {
             if (ModelState.IsValid)
             { 
             db.Entry(user).State = EntityState.Modified;
             db.SaveChanges();
             return RedirectToAction("Welcom");
             }
             ModelState.AddModelError("", "");
             return View();
         }

    }

}
