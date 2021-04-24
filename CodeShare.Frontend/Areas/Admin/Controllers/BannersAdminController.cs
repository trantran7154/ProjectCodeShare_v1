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
    public class BannersAdminController : Controller
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // GET: Admin/BannersAdmin
        public ActionResult Index()
        {
            return View(db.Banners.ToList());
        }

        // GET: Admin/BannersAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // GET: Admin/BannersAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BannersAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "banner_id,banner_title,banner_image,banner_link,banner_datecreate,banner_active")] Banner banner, HttpPostedFileBase img)
        {
            Random random = new Random();
            Random r = new Random();
            ViewBag.random = random.Next(0, 1000);

            db.Banners.Add(banner);

            if (img == null)
            {
                banner.banner_image = "notimg.png";
            }
            else
            {
                // Tên file ảnh sản phẩm
                var fileimg_cre = Path.GetFileName(img.FileName);
                // Đưa tên ảnh vào đúng file
                var pa_cre = Path.Combine(Server.MapPath("~/Images/Codes/"), ViewBag.random + fileimg_cre);

                img.SaveAs(pa_cre);
                banner.banner_image = ViewBag.random + img.FileName;

                banner.banner_active = true;
                banner.banner_datecreate = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banner);
        }

        // GET: Admin/BannersAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: Admin/BannersAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "banner_id,banner_title,banner_image,banner_link,banner_datecreate,banner_active")] Banner banner, HttpPostedFileBase img)
        {
            Random random = new Random();
            Random r = new Random();
            ViewBag.random = random.Next(0, 1000);

            db.Entry(banner).State = EntityState.Modified;

            if (img == null)
            {
                
            }
            else
            {
                // Tên file ảnh sản phẩm
                var fileimg_cre = Path.GetFileName(img.FileName);
                // Đưa tên ảnh vào đúng file
                var pa_cre = Path.Combine(Server.MapPath("~/Images/Codes/"), ViewBag.random + fileimg_cre);

                img.SaveAs(pa_cre);
                banner.banner_image = ViewBag.random + img.FileName;
            }

            banner.banner_active = true;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/BannersAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: Admin/BannersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banner banner = db.Banners.Find(id);
            db.Banners.Remove(banner);
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

        // Hoạt động Banner
        public JsonResult ActiveBanner(int? id)
        {
            Banner banner = db.Banners.Find(id);
            banner.banner_active = !banner.banner_active;
            db.SaveChanges();
            var list = from item in db.Banners
                       where item.banner_active == true
                       orderby item.banner_datecreate descending
                       select new
                       {
                           id = (int)item.banner_id,
                           title = item.banner_title,
                           active = item.banner_active,
                           img = item.banner_image,
                           link = item.banner_link,
                           datecreate = item.banner_datecreate.ToString()
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UnActive()
        {
            return View();
        }

        // Banner không hoạt động
        public JsonResult CheckActive(int? id)
        {
            var list = from item in db.Banners
                       where item.banner_active == false
                       orderby item.banner_datecreate descending
                       select new
                       {
                           id = (int)item.banner_id,
                           title = item.banner_title,
                           active = item.banner_active,
                           img = item.banner_image,
                           link = item.banner_link,
                           datecreate = item.banner_datecreate.ToString()
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        // Restore banner
        public JsonResult Restore(int? id)
        {
            Banner banner = db.Banners.Find(id);
            banner.banner_active = !banner.banner_active;
            db.SaveChanges();
            var list = from item in db.Banners
                       where item.banner_active == false
                       orderby item.banner_datecreate descending
                       select new
                       {
                           id = (int)item.banner_id,
                           title = item.banner_title,
                           active = item.banner_active,
                           img = item.banner_image,
                           link = item.banner_link,
                           datecreate = item.banner_datecreate.ToString()
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
