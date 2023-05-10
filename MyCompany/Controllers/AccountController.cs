using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCompany.Models;
using System.Web.Security;

namespace MyCompany.Controllers
{
    public class AccountController : Controller
    {
        // GET: Acount
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var context = new Company_ManqobaEntities1())
            {
                bool isValid = context.User.Any(x => x.Username == model.UserName && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);

                    return RedirectToAction("Index", "People");// This direct to the home page 
                }

                ModelState.AddModelError("", "Invalid username and password");
                return View();
            }
          
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User model)
        {
            using (var context = new Company_ManqobaEntities1())
            {
                context.User.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
       
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }

}