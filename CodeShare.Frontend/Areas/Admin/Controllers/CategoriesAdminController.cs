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
    public class CategoriesAdminController : Controller
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // GET: Admin/CategoriesAdmin
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["user_id"];
            if (cookie != null)
            {
                return View(db.Categorys.ToList());
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // GET: Admin/CategoriesAdmin/Details/5
        public ActionResult Details(int? id)
        {
            HttpCookie cookie = Request.Cookies["user_id"];
            if (cookie != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = db.Categorys.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // GET: Admin/CategoriesAdmin/Create
        public ActionResult Create()
        {
            HttpCookie cookie = Request.Cookies["user_id"];
            if (cookie != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // POST: Admin/CategoriesAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "category_id,category_name,category_active,category_item,category_img,category_datecreate,category_del,category_update")] Category category, HttpPostedFileBase img)
        {
            Random random = new Random();
            Random r = new Random();
            ViewBag.random = random.Next(0, 1000);

            db.Categorys.Add(category);

            if (img == null)
            {
                category.category_img = "notimg.png";
            }
            else
            {
                // Tên file ảnh sản phẩm
                var fileimg_cre = Path.GetFileName(img.FileName);
                // Đưa tên ảnh vào đúng file
                var pa_cre = Path.Combine(Server.MapPath("~/Images/Categorys/"), ViewBag.random + fileimg_cre);

                img.SaveAs(pa_cre);
                category.category_img = ViewBag.random + img.FileName;
            }

            category.category_active = true;
            category.category_del = false;
            category.category_datecreate = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/CategoriesAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            HttpCookie cookie = Request.Cookies["user_id"];
            if (cookie != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = db.Categorys.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // POST: Admin/CategoriesAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "category_id,category_name,category_active,category_item,category_img,category_datecreate,category_del,category_update")] Category category, HttpPostedFileBase img)
        {
            Random random = new Random();
            ViewBag.random = random.Next(0, 1000);

            db.Entry(category).State = EntityState.Modified;

            if (img == null)
            {
                
            }
            else
            {
                // Tên file ảnh sản phẩm
                var fileimg_cre = Path.GetFileName(img.FileName);
                // Đưa tên ảnh vào đúng file
                var pa_cre = Path.Combine(Server.MapPath("~/Images/Categorys/"), ViewBag.random + fileimg_cre);

                img.SaveAs(pa_cre);
                category.category_img = ViewBag.random + img.FileName;
            }

            category.category_del = false;
            category.category_dateupdate = DateTime.Now;
            category.category_active = true;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/CategoriesAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categorys.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/CategoriesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categorys.Find(id);
            db.Categorys.Remove(category);
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

        public JsonResult ActiveCate(int? id)
        {
            Category cate = db.Categorys.Find(id);
            cate.category_active = !cate.category_active;

            db.SaveChanges();

            var list = from item in db.Categorys
                       where item.category_del == false
                       orderby item.category_datecreate descending
                       select new
                       {
                           id = (int)item.category_id,
                           name = item.category_name,
                           active = item.category_active,
                           item = item.category_item,
                           img = item.category_img,
                           datecreate = item.category_datecreate.ToString(),
                           update = item.category_dateupdate.ToString(),
                           del = item.category_del
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Del(int? id)
        {
            Category cate = db.Categorys.Find(id);
            cate.category_del = !cate.category_del;

            db.SaveChanges();

            var list = from item in db.Categorys
                       where item.category_del == false
                       orderby item.category_datecreate descending
                       select new
                       {
                           id = (int)item.category_id,
                           name = item.category_name,
                           active = item.category_active,
                           item = item.category_item,
                           img = item.category_img,
                           datecreate = item.category_datecreate.ToString(),
                           update = item.category_dateupdate.ToString(),
                           del = item.category_del
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Deleted()
        {
            HttpCookie cookie = Request.Cookies["user_id"];
            if (cookie != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // Danh sách danh mục đã xóa
        public JsonResult DeletedCategories()
        {
            var list = from item in db.Categorys
                       where item.category_del == true
                       orderby item.category_datecreate descending
                       select new
                       {
                           id = (int)item.category_id,
                           name = item.category_name,
                           active = item.category_active,
                           item = item.category_item,
                           img = item.category_img,
                           datecreate = item.category_datecreate.ToString(),
                           update = item.category_dateupdate.ToString(),
                           del = item.category_del
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Khôi phục danh mục
        public JsonResult Restore(int? id)
        {
            Category cate = db.Categorys.Find(id);
            cate.category_del = !cate.category_del;

            db.SaveChanges();

            var list = from item in db.Categorys
                       where item.category_del == true
                       orderby item.category_datecreate descending
                       select new
                       {
                           id = (int)item.category_id,
                           name = item.category_name,
                           active = item.category_active,
                           item = item.category_item,
                           img = item.category_img,
                           datecreate = item.category_datecreate.ToString(),
                           update = item.category_dateupdate.ToString(),
                           del = item.category_del
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
