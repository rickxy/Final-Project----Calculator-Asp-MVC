using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;
using Calculator.Models;

namespace Calculator.Controllers
{
    public class AccountController : Controller
    {
        Entities3 Db = new Entities3();


        // GET: Login Page
        public ActionResult Login()
        {
            return View();
        }
        // GET: registration
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel credentials)
        {
            bool userExist = Db.UsersTbls.Any(x => x.Email == credentials.Username && x.Password == credentials.Password);
            UsersTbl u = Db.UsersTbls.FirstOrDefault(x => x.Email == credentials.Username && x.Password == credentials.Password);

            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return RedirectToAction("Main", "Home");

            }

            ModelState.AddModelError("", "Username or Password is wrong");
            return View();
        }

        [HttpPost]
        public ActionResult Signup(UsersTbl userinfo)
        {
            Db.UsersTbls.Add(userinfo);
            Db.SaveChanges();
            return RedirectToAction("Login");
        }
     
        public ActionResult Page2()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Page3()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index()
        {

            return View();
        }

    }
}