using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
			ViewBag.Message = "I love you, you.";
			return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Forgot to make my own branch and this is the only way i know to make a change ATM.  K bye.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}