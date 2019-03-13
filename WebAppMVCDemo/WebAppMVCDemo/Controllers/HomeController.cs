using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebAppMVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ModelState.AddModelError("","this is all wrong");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string UserName, string Password)
        {
            if (UserName == "sanshi" && Password == "pass")
            {
                FormsAuthentication.RedirectFromLoginPage("sanshi", false);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}