using System.Linq;
using System.Net;
using System.Web.Mvc;
using HtmlAgilityPack;
using Microsoft.Ajax.Utilities;
using Web.Models;
using Newtonsoft.Json;
using Web.Helpers;
using Web.Models.DTOs;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
		{
			ViewBag.Message = "Home Page";
            
		    var newsItems = _context.NewsItems.OrderByDescending(x => x.LastUpdated).Take(5).ToList();
		    var newsItemDtos = newsItems.Select(x => new NewsItemDto
		    {
		        Id = x.Id,
		        Title = x.Title,
		        CreatedBy = x.CreatedBy.Name,
		        LastUpdated = x.LastUpdated,
		        Headline = x.Headline,
                HeadlineImgSrc = AgilityPackHelper.GetFirstImageSrc(x.Body) != null && AgilityPackHelper.GetFirstImageSrc(x.Body) != "" ? AgilityPackHelper.GetFirstImageSrc(x.Body) : x.CreatedBy.PictureUrl
            }).ToList();
            
            return View(newsItemDtos);
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