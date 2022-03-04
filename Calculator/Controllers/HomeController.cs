using Calculator.Helpers;
using Calculator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System;
using System.Web;
using System.Web.Security;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Page2()
        {
            ViewBag.LastResult = GetLastResults();
            return View();
        }

        public ActionResult Page3()
        {
            ViewBag.LastResult = GetLastResults();
            return View();
        }

        public ActionResult Page4()
        {
            ViewBag.LastResult = GetLastResults();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Page2(CalculatorVM model)
        {
            double res = 0D;

            if (ModelState.IsValid)
            {
                switch (model.CommandText.ToLower())
                {
                    case "add":
                        res = model.FirstNumber + model.SecondNumber;
                        break;

                    case "sub":
                        res = model.FirstNumber - model.SecondNumber;
                        break;

                    case "mul":
                        res = model.FirstNumber * model.SecondNumber;
                        break;

                    case "div":
                        res = model.FirstNumber / model.SecondNumber;
                        break;
                    default:
                        break;
                }
                ViewBag.Result = res;
                SetLastResult(model, res);
                ViewBag.LastResult = GetLastResults();
                return View(model);
            }
            ViewBag.LastResult = GetLastResults();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Page3(CalculatorVM model)
        {
            double res = 0D;

            if (ModelState.IsValid)
            {
                switch (model.CommandText.ToLower())
                {
                    case "add":
                        res = model.FirstNumber + model.SecondNumber;
                        break;

                    case "sub":
                        res = model.FirstNumber - model.SecondNumber;
                        break;

                    case "mul":
                        res = model.FirstNumber * model.SecondNumber;
                        break;

                    case "div":
                        res = model.FirstNumber / model.SecondNumber;
                        break;
                    default:
                        break;
                }
                ViewBag.Result = res;
                SetLastResult(model, res);
                ViewBag.LastResult = GetLastResults();
                return View(model);
            }
            ViewBag.LastResult = GetLastResults();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Page4(CalculatorVM model)
        {
            double res = 0D;

            if (ModelState.IsValid)
            {
                switch (model.CommandText.ToLower())
                {
                    case "add":
                        res = model.FirstNumber + model.SecondNumber;
                        break;

                    case "sub":
                        res = model.FirstNumber - model.SecondNumber;
                        break;

                    case "mul":
                        res = model.FirstNumber * model.SecondNumber;
                        break;

                    case "dis":
                        res = (model.FirstNumber * model.SecondNumber) / 100;
                        break;

                    case "rng":
                        res = model.FirstNumber + model.SecondNumber;
                        break;

                    case "div":
                        res = model.FirstNumber / model.SecondNumber;
                        break;
                    default:
                        break;
                }
                ViewBag.Result = res;
                SetLastResult(model, res);
                ViewBag.LastResult = GetLastResults();
                return View(model);
            }
            ViewBag.LastResult = GetLastResults();
            return View(model);
        }
        private List<ResultVM> GetLastResults()
        {
            return Session["LastResults"] == null ? new List<ResultVM>() : (List<ResultVM>)Session["LastResults"];
        }

        private void SetLastResult(CalculatorVM model, double result)
        {
            var lastResults = Session["LastResults"] == null ? new List<ResultVM>() : (List<ResultVM>)Session["LastResults"];
            lastResults.Insert(0, new ResultVM
            {
                FirstNumber = model.FirstNumber,
                SecondNumber = model.SecondNumber,
                CommandText = model.CommandText,
                Result = result,
                CommandOperator = StringHelper.GetOperator(model.CommandText)
            });

            if (lastResults.Count > 3)
                Session["LastResults"] = lastResults.Take(3).ToList();
            else
                Session["LastResults"] = lastResults;
        }

        Entities2 Db = new Entities2();
        // GET: Account
        public ActionResult page5()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Page5(LoginModel credentials)
        {
            bool userExist = Db.UsersTbls.Any(x => x.Username == credentials.Username && x.Password == credentials.Password);
            UsersTbl u = Db.UsersTbls.FirstOrDefault(x => x.Username == credentials.Username && x.Password == credentials.Password);

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
            return RedirectToAction("Page5");
        }
        public ActionResult Index()
        {
            var Entities = new Entities2();
            return View(Entities.UsersTbls.ToList());
        }
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}