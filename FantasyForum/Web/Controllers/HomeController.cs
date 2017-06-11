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
			ViewBag.Message = "Fuck you";
			return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Luper wuz here 8===D";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}