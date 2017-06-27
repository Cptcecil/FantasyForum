using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class FrontPageLayoutController : Controller
    {
        // GET: FrontPageLayout
        public ActionResult Index()
        {
            return View();
        }
    }
}