using CodeShare.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Frontend.Functions;
using CodeShare.Model.DAO;

namespace CodeShare.Frontend.Controllers
{
    public class NewsController : Controller
    {
        DataShareCodeEntities db = new DataShareCodeEntities();
        NewsDao newsDao = new NewsDao();
        ImagesController images = new ImagesController();

        // GET: News
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News news, HttpPostedFileBase img, string[] tags)
        {
            if (ModelState.IsValid)
            {
                var co = new FunctionsController();
                var id = co.CookieID();
                string tag = "";
                foreach(var item in tags)
                {
                    tag += item + ";";
                }
                news.news_tag = tag;
                news.user_id = id.user_id;
                news.news_img = images.UpLoadImages(img, null, "News");
                newsDao.Create(news);

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News news, HttpPostedFileBase img, string[] tags)
        {
            if (ModelState.IsValid)
            {
                var co = new FunctionsController();
                var id = co.CookieID();
                string tag = "";
                foreach (var item in tags)
                {
                    tag += item + ";";
                }
                news.news_tag = tag;
                news.user_id = id.user_id;
                news.news_img = images.UpLoadImages(img, news.news_img, "News");
                newsDao.Edit(news);

                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int? id)
        {
            News news = db.News.Find(id);
            news.news_view += 1;
            db.SaveChanges();

            return View(news);
        }
    }
}