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
    public class LanguagesAdminController : Controller
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // GET: Admin/LanguagesAdmin
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                return View(db.Languages.ToList());
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // GET: Admin/LanguagesAdmin/Details/5
        public ActionResult Details(int? id)
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Language language = db.Languages.Find(id);
                if (language == null)
                {
                    return HttpNotFound();
                }
                return View(language);
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // GET: Admin/LanguagesAdmin/Create
        public ActionResult Create()
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // POST: Admin/LanguagesAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "language_id,language_name,language_active,language_img,language_view")] Language language, HttpPostedFileBase img)
        {
            Random random = new Random();
            Random r = new Random();
            ViewBag.random = random.Next(0, 1000);

            if (img == null)
            {
                language.language_img = "notimg.png";
            }
            else
            {
                // Tên file ảnh sản phẩm
                var fileimg_cre = Path.GetFileName(img.FileName);
                // Đưa tên ảnh vào đúng file
                var pa_cre = Path.Combine(Server.MapPath("~/Images/Languages/"), ViewBag.random + fileimg_cre);

                img.SaveAs(pa_cre);
                language.language_img = ViewBag.random + img.FileName;
            }

            language.language_active = 1;
            language.language_view = 0;

            db.Languages.Add(language);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/LanguagesAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Language language = db.Languages.Find(id);
                if (language == null)
                {
                    return HttpNotFound();
                }
                return View(language);
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // POST: Admin/LanguagesAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "language_id,language_name,language_active,language_img,language_view")] Language language, HttpPostedFileBase img)
        {
            Random random = new Random();
            Random r = new Random();
            ViewBag.random = random.Next(0, 1000);

            db.Entry(language).State = EntityState.Modified;

            if (img == null)
            {
                
            }
            else
            {
                // Tên file ảnh sản phẩm
                var fileimg_cre = Path.GetFileName(img.FileName);
                // Đưa tên ảnh vào đúng file
                var pa_cre = Path.Combine(Server.MapPath("~/Images/Languages/"), ViewBag.random + fileimg_cre);

                img.SaveAs(pa_cre);
                language.language_img = ViewBag.random + img.FileName;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/LanguagesAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // POST: Admin/LanguagesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Language language = db.Languages.Find(id);
            db.Languages.Remove(language);
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

        // Check trạng thái hoạt động của danh mục
        public JsonResult ActiveLanguages(int? id)
        {
            Language language = db.Languages.Find(id);
            if (language.language_active == 1)
            {
                language.language_active = 2;
            }
            else
            {
                language.language_active = 1;
            }
            db.SaveChanges();
            var list = from item in db.Languages
                       where item.language_active == 1
                       select new
                       {
                           id = (int)item.language_id,
                           name = item.language_name,
                           active = item.language_active,
                           img = item.language_img,
                           view = (int)item.language_view
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UnActive()
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // Check trạng thái hoạt động của danh mục
        public JsonResult ShowUnActive(int? id)
        {
            var list = from item in db.Languages
                       where item.language_active == 2
                       select new
                       {
                           id = (int)item.language_id,
                           name = item.language_name,
                           active = item.language_active,
                           img = item.language_img,
                           view = (int)item.language_view
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Check trạng thái hoạt động của danh mục
        public JsonResult Restore(int? id)
        {
            Language language = db.Languages.Find(id);
            if (language.language_active == 1)
            {
                language.language_active = 2;
            }
            else
            {
                language.language_active = 1;
            }
            db.SaveChanges();
            var list = from item in db.Languages
                       where item.language_active == 2
                       select new
                       {
                           id = (int)item.language_id,
                           name = item.language_name,
                           active = item.language_active,
                           img = item.language_img,
                           view = (int)item.language_view
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
