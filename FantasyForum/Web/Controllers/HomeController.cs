using System.Linq;
using System.Net;
using System.Web.Mvc;
using HtmlAgilityPack;
using Web.Models;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
		public ActionResult Index()
		{
			ViewBag.Message = "Home Page";

            return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "About";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
        public ActionResult Forum()
        {
            ViewBag.Message = "Forum.";

            return View();
        }
    }
}