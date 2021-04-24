using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class NewsAdminController : Controller
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // GET: Admin/NewsAdmin
        public ActionResult Index()
        {
            var news = db.News.Include(n => n.User);
            return View(news.ToList());
        }

        // GET: Admin/NewsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: Admin/NewsAdmin/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email");
            return View();
        }

        // POST: Admin/NewsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "news_id,news_name,news_view,news_content,news_tag,user_id,news_datecreate,news_dateupdate,news_active,news_option,news_del,news_img")] News news, HttpPostedFileBase img)
        {
            Random random = new Random();
            Random r = new Random();
            ViewBag.random = random.Next(0, 1000);

            db.News.Add(news);

            if (img == null)
            {
                news.news_img = "notimg.png";
            }
            else
            {
                // Tên file ảnh sản phẩm
                var fileimg_cre = Path.GetFileName(img.FileName);
                // Đưa tên ảnh vào đúng file
                var pa_cre = Path.Combine(Server.MapPath("~/Images/News/"), ViewBag.random + fileimg_cre);

                img.SaveAs(pa_cre);
                news.news_img = ViewBag.random + img.FileName;

                news.news_view = 0;
                news.news_datecreate = DateTime.Now;
                news.news_active = 1;
                news.news_option = true;
                news.news_del = false;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", news.user_id);
            return View(news);
        }

        // GET: Admin/NewsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", news.user_id);
            return View(news);
        }

        // POST: Admin/NewsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "news_id,news_name,news_view,news_content,news_tag,user_id,news_datecreate,news_dateupdate,news_active,news_option,news_del,news_img")] News news, HttpPostedFileBase img)
        {

            Random random = new Random();
            Random r = new Random();
            ViewBag.random = random.Next(0, 1000);

            db.Entry(news).State = EntityState.Modified;

            if (img == null)
            {
                
            }
            else
            {
                // Tên file ảnh sản phẩm
                var fileimg_cre = Path.GetFileName(img.FileName);
                // Đưa tên ảnh vào đúng file
                var pa_cre = Path.Combine(Server.MapPath("~/Images/News/"), ViewBag.random + fileimg_cre);

                img.SaveAs(pa_cre);
                news.news_img = ViewBag.random + img.FileName;
            }

            news.news_active = 1;
            news.news_option = true;
            news.news_del = false;
            news.news_dateupdate = DateTime.Now;

            db.SaveChanges();
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", news.user_id);
            return RedirectToAction("Index", "NewsAdmin");
        }

        // GET: Admin/NewsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Admin/NewsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Check trạng thái hoạt động của News
        public JsonResult ActiveNew(int? id)
        {
            News news = db.News.Find(id);
            if (news.news_active == 1)
            {
                news.news_active = 2;
            }
            else
            {
                news.news_active = 1;
            }
            db.SaveChanges();
            var list = from item in db.News
                       where item.news_del == false
                       orderby item.news_datecreate descending
                       select new
                       {
                           id = (int)item.news_id,
                           name = item.news_name.ToString(),
                           view = (int)item.news_view,
                           content = item.news_content.ToString(),
                           tag = item.news_tag.ToString(),
                           user_id = (int)item.user_id,
                           user_name = item.User.user_name.ToString(),
                           datecreate = item.news_datecreate.ToString(),
                           update = item.news_dateupdate.ToString(),
                           active = (int)item.news_active,
                           option = item.news_option,
                           del = item.news_del,
                           img = item.news_img
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Check trạng thái của News
        public JsonResult OptionNew(int? id)
        {
            News news = db.News.Find(id);
            news.news_option = !news.news_option;
            db.SaveChanges();
            var list = from item in db.News
                       where item.news_del == false
                       orderby item.news_datecreate descending
                       select new
                       {
                           id = (int)item.news_id,
                           name = item.news_name.ToString(),
                           view = (int)item.news_view,
                           content = item.news_content.ToString(),
                           tag = item.news_tag.ToString(),
                           user_id = (int)item.user_id,
                           user_name = item.User.user_name.ToString(),
                           datecreate = item.news_datecreate.ToString(),
                           update = item.news_dateupdate.ToString(),
                           active = (int)item.news_active,
                           option = item.news_option,
                           del = item.news_del,
                           img = item.news_img
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Xóa News
        public JsonResult DelNew(int? id)
        {
            News news = db.News.Find(id);
            news.news_del = !news.news_del;
            db.SaveChanges();
            var list = from item in db.News
                       where item.news_del == false
                       orderby item.news_datecreate descending
                       select new
                       {
                           id = (int)item.news_id,
                           name = item.news_name.ToString(),
                           view = (int)item.news_view,
                           content = item.news_content.ToString(),
                           tag = item.news_tag.ToString(),
                           user_id = (int)item.user_id,
                           user_name = item.User.user_name.ToString(),
                           datecreate = item.news_datecreate.ToString(),
                           update = item.news_dateupdate.ToString(),
                           active = (int)item.news_active,
                           option = item.news_option,
                           del = item.news_del,
                           img = item.news_img
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Deleted()
        {
            return View();
        }

        public JsonResult ShowBin()
        {
            var list = from item in db.News
                       where item.news_del == true
                       orderby item.news_datecreate descending
                       select new
                       {
                           id = (int)item.news_id,
                           name = item.news_name.ToString(),
                           view = (int)item.news_view,
                           content = item.news_content.ToString(),
                           tag = item.news_tag.ToString(),
                           user_id = (int)item.user_id,
                           user_name = item.User.user_name.ToString(),
                           datecreate = item.news_datecreate.ToString(),
                           update = item.news_dateupdate.ToString(),
                           active = (int)item.news_active,
                           option = item.news_option,
                           del = item.news_del,
                           img = item.news_img
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        // Khôi phục News
        public JsonResult Restore(int? id)
        {
            News news = db.News.Find(id);
            news.news_del = !news.news_del;
            db.SaveChanges();
            var list = from item in db.News
                       where item.news_del == true
                       orderby item.news_datecreate descending
                       select new
                       {
                           id = (int)item.news_id,
                           name = item.news_name.ToString(),
                           view = (int)item.news_view,
                           content = item.news_content.ToString(),
                           tag = item.news_tag.ToString(),
                           user_id = (int)item.user_id,
                           user_name = item.User.user_name.ToString(),
                           datecreate = item.news_datecreate.ToString(),
                           update = item.news_dateupdate.ToString(),
                           active = (int)item.news_active,
                           option = item.news_option,
                           del = item.news_del,
                           img = item.news_img
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
