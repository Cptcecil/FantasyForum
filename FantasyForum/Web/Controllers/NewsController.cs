using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Models.DTOs;
using Web.Helpers;

namespace Web.Controllers
{
    public class NewsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public NewsController()
        {
            _context = new ApplicationDbContext();
        }
        
        public ActionResult Index()
        {
            ViewBag.Message = "Home Page";

            var user = _context.Users.SingleOrDefault(x => x.Email == User.Identity.Name);
            var newsItems = _context.NewsItems.OrderByDescending(x => x.LastUpdated).ToList();
            var newsItemDtos = newsItems.Select(x => new NewsItemDto
            {
                Id = x.Id,
                Title = x.Title,
                CreatedBy = x.CreatedBy.Name,
                LastUpdated = x.LastUpdated,
                Headline = x.Headline,
                HeadlineImgSrc = AgilityPackHelper.GetFirstImageSrc(x.Body) != null && AgilityPackHelper.GetFirstImageSrc(x.Body) != "" ? AgilityPackHelper.GetFirstImageSrc(x.Body) : x.CreatedBy.PictureUrl,
                CanEdit = user != null && x.CreatedBy.Id == user.Id ? true : false
            }).ToList();

            return View(newsItemDtos);
        }

        [Authorize]
        public ActionResult MyArticles()
        {
            ViewBag.Message = "Home Page";

            var user = _context.Users.SingleOrDefault(x => x.Email == User.Identity.Name);
            var newsItems = _context.NewsItems.Where(x=>x.CreatedById == user.Id).OrderByDescending(x => x.LastUpdated).ToList();
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

        public ActionResult Details(int id)
        {
            var newsItem = _context.NewsItems.Find(id);
            return View(newsItem);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        
        [Authorize]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(NewsItem newsItem)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Email == User.Identity.Name);
                if (ModelState.IsValid && user != null)
                {
                    newsItem.LastUpdated = DateTime.UtcNow;
                    newsItem.CreatedById = user.Id;
                    _context.NewsItems.Add(newsItem);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View(_context.NewsItems.Find(id));
        }
        
        [Authorize]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(NewsItem newsItem)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Email == User.Identity.Name);
                if (ModelState.IsValid)
                {
                    var item = _context.NewsItems.Find(newsItem.Id);

                    if (item.CreatedById != user.Id)
                        return View();

                    item.Title = newsItem.Title;
                    item.Body = newsItem.Body;
                    item.LastUpdated = DateTime.UtcNow;
                    _context.SaveChanges();
                    return RedirectToAction("MyArticles", "News");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //// GET: News/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: News/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
