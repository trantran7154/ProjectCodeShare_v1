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
using CodeShare.Model.DAO;
using CodeShare.Frontend.Functions;
using CodeShare.Frontend.ViewModels;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class UsersAdminController : Controller
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();
        UsersDao usersDAO = new UsersDao();
        FunctionsController function = new FunctionsController();

        // GET: Admin/UsersAdmin
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                return View(db.Users.ToList());
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        public PartialViewResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(ViewLogin login)
        {
            if (function.CookieID() != null)
            {
                return Redirect("/");
            }
            if (ModelState.IsValid)
            {
                int status = usersDAO.LoginAdmin(login.Email, login.Password);
                switch (status)
                {
                    case 1:
                        var user = db.Users.FirstOrDefault(t => t.user_email == login.Email && t.user_pass == login.Password);
                        HttpCookie cookie = new HttpCookie("admin_id", user.user_id.ToString());
                        cookie.Expires.AddDays(10);
                        Response.Cookies.Set(cookie);
                        return RedirectToAction("Index","HomeAdmin");
                    case -1:
                        TempData["noti_login"] = "Sai tài khoản hoặc mật khẩu!";
                        break;
                    case -2:
                        TempData["noti_login"] = "Tài khoản của bạn đã bị xóa!";
                        break;
                    case -3:
                        TempData["noti_login"] = "Tài khoản của bạn đã bị khóa!";
                        break;
                    default:
                        TempData["noti_login"] = "Tài khoản của bạn không tồn tại!";
                        break;
                }
            }
            return View(login);
        }

        // SignOut
        public ActionResult LogOut()
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            cookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Set(cookie);

            return RedirectToAction("Login","UsersAdmin");
        }

        // GET: Admin/UsersAdmin/Details/5
        public ActionResult Details(int? id)
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // GET: Admin/UsersAdmin/Create
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

        // POST: Admin/UsersAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_email,user_phone,user_sex,user_birth,user_token,user_role,user_name,user_coin,user_datecreate,user_dateupdate,user_code,user_active,user_option,user_del,user_fa,user_none,user_view,user_facode,user_pass,user_img")] User user, HttpPostedFileBase img)
        {
            Random random = new Random();
            Random r = new Random();
            ViewBag.random = random.Next(0, 1000);

            if (img == null)
            {
                user.user_img = "notimg.png";
            }
            else
            {
                // Tên file ảnh sản phẩm
                var fileimg_cre = Path.GetFileName(img.FileName);
                // Đưa tên ảnh vào đúng file
                var pa_cre = Path.Combine(Server.MapPath("~/Images/Users/"), ViewBag.random + fileimg_cre);

                img.SaveAs(pa_cre);
                user.user_img = ViewBag.random + img.FileName;
            }

            user.user_datecreate = DateTime.Now;
            user.user_del = false;
            user.user_option = true;
            user.user_active = 1;
            user.user_view = 0;
            user.user_token = Guid.NewGuid().ToString();
            user.user_coin = 0;

            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/UsersAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // POST: Admin/UsersAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_email,user_phone,user_sex,user_birth,user_token,user_role,user_name,user_coin,user_datecreate,user_dateupdate,user_code,user_active,user_option,user_del,user_fa,user_none,user_view,user_facode,user_pass,user_img")] User user, HttpPostedFileBase img)
        {
            Random random = new Random();
            ViewBag.random = random.Next(0, 1000);

            db.Entry(user).State = EntityState.Modified;

            if (img == null)
            {
                
            }
            else
            {
                // Tên file ảnh sản phẩm
                var fileimg_ed = Path.GetFileName(img.FileName);
                // Đưa tên ảnh vào đúng file
                var pa_ed = Path.Combine(Server.MapPath("~/Images/Users/"), ViewBag.random + fileimg_ed);

                img.SaveAs(pa_ed);
                user.user_img = ViewBag.random + img.FileName;
            }

            user.user_del = false;
            user.user_option = true;
            user.user_dateupdate = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/UsersAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/UsersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

        public JsonResult Del(int? id)
        {
            User user = db.Users.Find(id);
            user.user_del = !user.user_del;

            db.SaveChanges();

            var list = from item in db.Users
                       where item.user_del == false
                       orderby item.user_datecreate descending
                       select new
                       {
                           id = item.user_id,
                           email = item.user_email,
                           phone = item.user_phone,
                           sex = item.user_sex,
                           birth = item.user_birth.ToString(),
                           token = item.user_token,
                           role = item.user_role,
                           name = item.user_name,
                           coin = item.user_coin,
                           datecreate = item.user_datecreate.ToString(),
                           dateupdate = item.user_dateupdate.ToString(),
                           code = item.user_code,
                           active = (int)item.user_active,
                           option = item.user_option,
                           del = item.user_del,
                           fa = item.user_fa,
                           none = item.user_none,
                           view = item.user_view,
                           facode = item.user_facode,
                           pass = item.user_pass,
                           img = item.user_img
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Restore(int? id)
        {
            User user = db.Users.Find(id);
            user.user_del = !user.user_del;

            db.SaveChanges();

            var list = from item in db.Users
                       where item.user_del == true
                       orderby item.user_datecreate descending
                       select new
                       {
                           id = item.user_id,
                           email = item.user_email,
                           phone = item.user_phone,
                           sex = item.user_sex,
                           birth = item.user_birth.ToString(),
                           token = item.user_token,
                           role = item.user_role,
                           name = item.user_name,
                           coin = item.user_coin,
                           datecreate = item.user_datecreate.ToString(),
                           dateupdate = item.user_dateupdate.ToString(),
                           code = item.user_code,
                           active = (int)item.user_active,
                           option = item.user_option,
                           del = item.user_del,
                           fa = item.user_fa,
                           none = item.user_none,
                           view = item.user_view,
                           facode = item.user_facode,
                           pass = item.user_pass,
                           img = item.user_img
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

        public JsonResult DeletedUsers()
        {
            var list = from item in db.Users
                       where item.user_del == true
                       orderby item.user_datecreate descending
                       select new
                       {
                           id = (int)item.user_id,
                           email = item.user_email,
                           phone = item.user_phone,
                           sex = item.user_sex,
                           birth = item.user_birth.ToString(),
                           token = item.user_token,
                           role = (int)item.user_role,
                           name = item.user_name,
                           coin = (int)item.user_coin,
                           datecreate = item.user_datecreate.ToString(),
                           dateupdate = item.user_dateupdate.ToString(),
                           code = item.user_code,
                           active = (int)item.user_active,
                           option = item.user_option,
                           del = item.user_del,
                           fa = item.user_fa,
                           none = item.user_none,
                           view = (int)item.user_view,
                           facode = item.user_facode,
                           pass = item.user_pass,
                           img = item.user_img
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Check trạng thái hoạt động của Users
        public JsonResult ActiveUser(int? id)
        {
            User user = db.Users.Find(id);
            if (user.user_active == 1)
            {
                user.user_active = 2;
            }
            else
            {
                user.user_active = 1;
            }
            db.SaveChanges();
            var list = from item in db.Users
                       where item.user_del == false
                       orderby item.user_datecreate descending
                       select new
                       {
                           id = (int)item.user_id,
                           email = item.user_email,
                           phone = item.user_phone,
                           sex = item.user_sex,
                           birth = item.user_birth.ToString(),
                           token = item.user_token,
                           role = (int)item.user_role,
                           name = item.user_name,
                           coin = (int)item.user_coin,
                           datecreate = item.user_datecreate.ToString(),
                           dateupdate = item.user_dateupdate.ToString(),
                           code = item.user_code,
                           active = (int)item.user_active,
                           option = item.user_option,
                           del = item.user_del,
                           fa = item.user_fa,
                           none = item.user_none,
                           view = (int)item.user_view,
                           facode = item.user_facode,
                           pass = item.user_pass,
                           img = item.user_img
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Check trạng thái xóa của Users
        public JsonResult OptionUser(int? id)
        {
            User user = db.Users.Find(id);
            user.user_option = !user.user_option;
            db.SaveChanges();
            var list = from item in db.Users
                       where item.user_del == false
                       orderby item.user_datecreate descending
                       select new
                       {
                           id = (int)item.user_id,
                           email = item.user_email,
                           phone = item.user_phone,
                           sex = item.user_sex,
                           birth = item.user_birth.ToString(),
                           token = item.user_token,
                           role = (int)item.user_role,
                           name = item.user_name,
                           coin = (int)item.user_coin,
                           datecreate = item.user_datecreate.ToString(),
                           dateupdate = item.user_dateupdate.ToString(),
                           code = item.user_code,
                           active = (int)item.user_active,
                           option = item.user_option,
                           del = item.user_del,
                           fa = item.user_fa,
                           none = item.user_none,
                           view = (int)item.user_view,
                           facode = item.user_facode,
                           pass = item.user_pass,
                           img = item.user_img
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Lịch sử nạp xu
        public ActionResult MoneyHistory(int? id)
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                User users = db.Users.Find(id);
                return View(users);
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // Lịch sử bình luận
        public ActionResult CommetHistory(int? id)
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                User users = db.Users.Find(id);
                return View(users);
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }
    }
}
