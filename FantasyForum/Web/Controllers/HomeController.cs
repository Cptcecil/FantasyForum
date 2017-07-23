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
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

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

        [Authorize]
        public ActionResult RandomTeamOrder()
	    {
	        return View();
        }

        [Authorize]
        public ActionResult MyTeam()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == User.Identity.Name);
            return View(user.UserWrestlers?.OrderBy(x=>x.Order).Select(x=>x.Wrestler).ToList());
        }

        [Authorize]
        public ActionResult ChooseTeam()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == User.Identity.Name);
            var wrestlers = _context.Wrestlers.ToList();
	        return View(wrestlers);
        }

        [Authorize]
        public ActionResult AddWrestlers(string wrestlers)
        {
            var wrestlerIds = JsonConvert.DeserializeObject<int[]>(wrestlers);

            var user = _context.Users.SingleOrDefault(x => x.Email == User.Identity.Name);

            _context.UserWrestlers.RemoveRange(_context.UserWrestlers.Where(x => x.UserId == user.Id));

            UserWrestler toAddUserWrestler = new UserWrestler();
            for (int i = 1; i <= wrestlerIds.Length; i++)
            {
                toAddUserWrestler = new UserWrestler
                {
                    UserId = user.Id,
                    WrestlerId = wrestlerIds[i-1],
                    Order = i
                };
                user.UserWrestlers.Add(toAddUserWrestler);
            }
            
            _context.SaveChanges();
            return RedirectToAction("MyTeam");
        }
    }
}