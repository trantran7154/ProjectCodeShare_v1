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
    public class CodesAdminController : Controller
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // GET: Admin/Codes
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                var codes = db.Codes.Include(c => c.Category).Include(c => c.User);
                return View(codes.ToList());
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // GET: Admin/Codes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Code code = db.Codes.Find(id);
            if (code == null)
            {
                return HttpNotFound();
            }
            return View(code);
        }

        // GET: Admin/Codes/Create
        public ActionResult Create()
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                ViewBag.category_id = new SelectList(db.Categorys, "category_id", "category_name");
                ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // POST: Admin/Codes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "code_id,code_title,code_coin,code_code,code_des,code_info,code_setting,code_view,code_viewdown,code_linkdemo,code_linkdown,code_datecreate,code_dateupdate,code_active,code_option,code_del,code_tag,code_disk,code_pass,category_id,user_id,code_img,code_key")] Code code, HttpPostedFileBase img, int[] language)
        {
            Random random = new Random();
            Random r = new Random();
            ViewBag.random = random.Next(0, 1000);

            var key = Guid.NewGuid().ToString();

            if (img == null)
            {
                code.code_img = "notimg.png";
            }
            else
            {
                // Tên file ảnh sản phẩm
                var fileimg_cre = Path.GetFileName(img.FileName);
                // Đưa tên ảnh vào đúng file
                var pa_cre = Path.Combine(Server.MapPath("~/Images/Codes/"), ViewBag.random + fileimg_cre);

                img.SaveAs(pa_cre);
                code.code_img = ViewBag.random + img.FileName;
            }

            code.code_datecreate = DateTime.Now;
            code.code_view = 0;
            code.code_viewdown = 0;
            code.code_active = 2;
            code.code_option = true;
            code.code_del = false;
            code.code_key = key;
            if (code.code_coin == null)
            {
                code.code_coin = 0;
            }
            code.code_code = "CODE-" + r.Next().ToString();

            db.Codes.Add(code);
            db.SaveChanges();

            Code code1 = db.Codes.SingleOrDefault(n => n.code_key == key);

            foreach (var item in language)
            {
                // add multiple tag for code
                Group group = new Group()
                {
                    code_id = code1.code_id,
                    language_id = item,
                    group_item = Common.Common.ITEM_LANGUAGE_CODE
                };
                db.Groups.Add(group);
                db.SaveChanges();
            }

            ViewBag.category_id = new SelectList(db.Categorys, "category_id", "category_name", code.category_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", code.user_id);
            return RedirectToAction("Index");
        }

        // GET: Admin/Codes/Edit/5
        public ActionResult Edit(int? id)
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Code code = db.Codes.Find(id);
                if (code == null)
                {
                    return HttpNotFound();
                }
                ViewBag.category_id = new SelectList(db.Categorys, "category_id", "category_name", code.category_id);
                ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", code.user_id);
                return View(code);
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // POST: Admin/Codes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "code_id,code_title,code_coin,code_code,code_des,code_info,code_setting,code_view,code_viewdown,code_linkdemo,code_linkdown,code_datecreate,code_dateupdate,code_active,code_option,code_del,code_tag,code_disk,code_pass,category_id,user_id,code_img,code_key")] Code code, HttpPostedFileBase img, int[] language)
        {
            Random random = new Random();
            ViewBag.random = random.Next(0, 1000);

            db.Entry(code).State = EntityState.Modified;

            if (img == null)
            {

            }
            else
            {
                // Tên file ảnh sản phẩm
                var fileimg_ed = Path.GetFileName(img.FileName);
                // Đưa tên ảnh vào đúng file
                var pa_ed = Path.Combine(Server.MapPath("~/Images/Codes/"), ViewBag.random + fileimg_ed);

                img.SaveAs(pa_ed);
                code.code_img = ViewBag.random + img.FileName;
            }

            code.code_del = false;
            code.code_option = true;
            code.code_dateupdate = DateTime.Now;
            db.SaveChanges();

            // remove old tags
            foreach (var item in code.Groups)
            {
                db.Groups.Remove(item);
            }
            foreach (var item in language)
            {
                // add multiple tag for code
                Group group = new Group()
                {
                    code_id = code.code_id,
                    language_id = item,
                    group_item = Common.Common.ITEM_LANGUAGE_CODE
                };
                db.SaveChanges();
            }
            ViewBag.category_id = new SelectList(db.Categorys, "category_id", "category_name", code.category_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", code.user_id);
            return RedirectToAction("Index", "CodesAdmin");
        }

        public JsonResult Del(int? id)
        {
            Code code = db.Codes.Find(id);
            code.code_del = !code.code_del;

            db.SaveChanges();

            var list = from item in db.Codes
                       where item.code_del == false
                       orderby item.code_datecreate descending
                       select new
                       {
                           active = (int)item.code_active,
                           code = item.code_code,
                           coin = (int)item.code_coin,
                           datecreate = item.code_datecreate.ToString(),
                           dateupdate = item.code_dateupdate.ToString(),
                           del = item.code_del,
                           des = item.code_des,
                           disk = (int)(item.code_disk == null ? 0 : item.code_disk),
                           id = item.code_id,
                           id_cate = (int)item.category_id,
                           id_us = (int)item.user_id,
                           info = item.code_info,
                           linkdemo = item.code_linkdemo,
                           linkdown = item.code_linkdown,
                           option = item.code_option,
                           pass = item.code_pass,
                           setting = item.code_setting,
                           tag = item.code_tag,
                           title = item.code_title,
                           view = (int)item.code_view,
                           viewdown = (int)item.code_viewdown,
                           img = item.code_img,
                           cate_name = item.Category.category_name,
                           user_name = item.User.user_name
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Restore(int? id)
        {
            Code code = db.Codes.Find(id);
            code.code_del = !code.code_del;

            db.SaveChanges();

            var list = from item in db.Codes
                       where item.code_del == true
                       orderby item.code_datecreate descending
                       select new
                       {
                           active = (int)item.code_active,
                           code = item.code_code,
                           coin = (int)item.code_coin,
                           datecreate = item.code_datecreate.ToString(),
                           dateupdate = item.code_dateupdate.ToString(),
                           del = item.code_del,
                           des = item.code_des,
                           disk = (int)(item.code_disk == null ? 0 : item.code_disk),
                           id = item.code_id,
                           id_cate = (int)item.category_id,
                           id_us = (int)item.user_id,
                           info = item.code_info,
                           linkdemo = item.code_linkdemo,
                           linkdown = item.code_linkdown,
                           option = item.code_option,
                           pass = item.code_pass,
                           setting = item.code_setting,
                           tag = item.code_tag,
                           title = item.code_title,
                           view = (int)item.code_view,
                           viewdown = (int)item.code_viewdown,
                           img = item.code_img,
                           cate_name = item.Category.category_name,
                           user_name = item.User.user_name
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Codes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Code code = db.Codes.Find(id);
            if (code == null)
            {
                return HttpNotFound();
            }
            return View(code);
        }

        // POST: Admin/Codes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Code code = db.Codes.Find(id);
            code.code_del = !code.code_del;
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

        // Check trạng thái hoạt động của Codes
        public JsonResult ActiveCode(int? id)
        {
            Code codes = db.Codes.Find(id);
            if(codes.code_active == 1)
            {
                codes.code_active = 2;
            }
            else
            {
                codes.code_active = 1;
            }
            db.SaveChanges();
            var list = from item in db.Codes
                       where item.code_del == false
                       orderby item.code_datecreate descending
                       select new
                       {
                           active = (int)item.code_active,
                           code = item.code_code,
                           coin = (int)item.code_coin,
                           datecreate = item.code_datecreate.ToString(),
                           dateupdate = item.code_dateupdate.ToString(),
                           del = item.code_del,
                           des = item.code_des,
                           disk = (int)(item.code_disk == null ? 0 : item.code_disk),
                           id = item.code_id,
                           id_cate = (int)item.category_id,
                           id_us = (int)item.user_id,
                           info = item.code_info,
                           linkdemo = item.code_linkdemo,
                           linkdown = item.code_linkdown,
                           option = item.code_option,
                           pass = item.code_pass,
                           setting = item.code_setting,
                           tag = item.code_tag,
                           title = item.code_title,
                           view = (int)item.code_view,
                           viewdown = (int)item.code_viewdown,
                           img = item.code_img,
                           cate_name = item.Category.category_name,
                           user_name = item.User.user_name
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Check trạng thái của Codes
        public JsonResult OptionCode(int? id)
        {
            Code codes = db.Codes.Find(id);
            codes.code_option = !codes.code_option;
            db.SaveChanges();
            var list = from item in db.Codes
                       where item.code_del == false
                       orderby item.code_datecreate descending
                       select new
                       {
                           active = (int)item.code_active,
                           code = item.code_code,
                           coin = (int)item.code_coin,
                           datecreate = item.code_datecreate.ToString(),
                           dateupdate = item.code_dateupdate.ToString(),
                           del = item.code_del,
                           des = item.code_des,
                           disk = (int)(item.code_disk == null ? 0 : item.code_disk),
                           id = item.code_id,
                           id_cate = (int)item.category_id,
                           id_us = (int)item.user_id,
                           info = item.code_info,
                           linkdemo = item.code_linkdemo,
                           linkdown = item.code_linkdown,
                           option = item.code_option,
                           pass = item.code_pass,
                           setting = item.code_setting,
                           tag = item.code_tag,
                           title = item.code_title,
                           view = (int)item.code_view,
                           viewdown = (int)item.code_viewdown,
                           img = item.code_img,
                           cate_name = item.Category.category_name,
                           user_name = item.User.user_name
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Deleted()
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

        // Danh sách code đã xóa
        public JsonResult DeletedCodes()
        {
            var list = from item in db.Codes
                       where item.code_del == true
                       orderby item.code_datecreate descending
                       select new
                       {
                           active = (int)item.code_active,
                           code = item.code_code,
                           coin = (int)item.code_coin,
                           datecreate = item.code_datecreate.ToString(),
                           dateupdate = item.code_dateupdate.ToString(),
                           del = item.code_del,
                           des = item.code_des,
                           disk = (int)(item.code_disk == null ? 0 : item.code_disk),
                           id = item.code_id,
                           id_cate = (int)item.category_id,
                           id_us = (int)item.user_id,
                           info = item.code_info,
                           linkdemo = item.code_linkdemo,
                           linkdown = item.code_linkdown,
                           option = item.code_option,
                           pass = item.code_pass,
                           setting = item.code_setting,
                           tag = item.code_tag,
                           title = item.code_title,
                           view = (int)item.code_view,
                           viewdown = (int)item.code_viewdown,
                           img = item.code_img,
                           cate_name = item.Category.category_name,
                           user_name = item.User.user_name
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
