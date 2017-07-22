using System.Linq;
using System.Net;
using System.Web.Mvc;
using HtmlAgilityPack;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

		public ActionResult Index()
		{
			ViewBag.Message = "Home Page";

		    //using (WebClient client = new WebClient())
		    //{
		    //    ApplicationDbContext context = new ApplicationDbContext();

		    //    string htmlCode = client.DownloadString("https://www.giantbomb.com/wwf-no-mercy/3030-11394/characters/?page=2");
		    //    var doc = new HtmlDocument();
      //          doc.LoadHtml(htmlCode);
		    //    var wrestler = new Wrestler();
		    //    var imgs = doc.DocumentNode.SelectNodes("//ul[@class='editorial']/li/a/div/img");
		    //    var names = doc.DocumentNode.SelectNodes("//ul[@class='editorial']/li/a/h3");
		    //    var descriptions = doc.DocumentNode.SelectNodes("//ul[@class='editorial']/li/a/p");

      //          for(int i = 0; i< imgs.Count(); i++)
		    //    {
		    //        wrestler = new Wrestler
		    //        {
		    //            PictureUrl = imgs[i].GetAttributeValue("src", ""),
		    //            Name = names[i].InnerText,
		    //            Description = descriptions[i].InnerText.Replace("\n", "").Trim()
		    //        };

		    //        context.Wrestlers.Add(wrestler);
		    //    }

		    //    context.SaveChanges();
		    //}



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

	    public ActionResult RandomTeamOrder()
	    {
	        return View();
	    }

        public ActionResult ChooseTeam()
        {
            var wrestlers = _context.Wrestlers.ToList();
	        return View(wrestlers);
	    }
    }
}