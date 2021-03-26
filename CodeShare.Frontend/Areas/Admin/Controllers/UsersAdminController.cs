using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Frontend.Functions;
using CodeShare.Model.DAO;
using CodeShare.Model.EF;
using CodeShare.Common;
using CodeShare.Frontend.Models;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class UsersAdminController : Controller
    {
        // GET: Admin/UsersAdmin

        CodeShareDataEntities db = new CodeShareDataEntities();

        public ActionResult Index()
        {
            return View(db.Users.Where(n => n.user_bin == false).ToList());
        }

        // Create
        public ActionResult CreateUser(Users users, HttpPostedFileBase IMG)
        {
            var user = Guid.NewGuid().ToString();
            var addimg = new ImagesController();

            users.user_active = true;
            users.user_option = true;

            users.user_bin = false;

            users.user_datelogin = DateTime.Now;
            users.user_token = Guid.NewGuid().ToString();
            users.user_code = "#CODE-" + users.user_id;

            if (IMG == null)
            {
                users.user_img = "notimg.png";
            }
            else
            {

                addimg.AddImages(IMG, Common.Links.IMG_COURSES, user);
                users.user_img = user + IMG.FileName;
            }

            var dao = new UsersDAO();
            if (dao.Create(users))
            {
                return RedirectToAction("CreateCode", new { id = users.user_id });
            }
            else
            {
                return Redirect(Common.Links.NOT_404);
            }
        }

        public RedirectResult CreateCode(int? id)
        {
            Users users = db.Users.Find(id);

            users.user_code = "#COD-8939" + id;

            db.SaveChanges();

            HttpCookie httpCookie = new HttpCookie("user_id", id.ToString());
            httpCookie.Expires.AddDays(10);
            Response.Cookies.Set(httpCookie);

            return Redirect("/Admin/UsersAdmin/Index");
        }

        // Edit
        public ActionResult EditUser(Users users, HttpPostedFileBase IMG)
        {
            var user = Guid.NewGuid().ToString();
            var addimg = new ImagesController();

            users.user_active = true;
            users.user_option = true;

            users.user_bin = false;

            Users users1 = db.Users.Find(users.user_id);

            if (IMG == null)
            {
                users.user_img = users1.user_img;
            }
            else
            {

                addimg.AddImages(IMG, Common.Links.IMG_COURSES, user);
                users.user_img = user + IMG.FileName;
            }

            var dao = new UsersDAO();
            if (dao.Create(users))
            {
                return Redirect("/Admin/UsersAdmin/Index");
            }
            else
            {
                return Redirect(Common.Links.NOT_404);
            }
        }

        // Active
        public JsonResult ActiveUser(int? id)
        {
            var dao = new UsersDAO();
            if (dao.Active(id))
            {
                // Giá trị Angular
                List<Users> users = db.Users.Where(n => n.user_bin == false).OrderByDescending(n => n.user_datecreate).ToList();
                // Tên biến
                List<jUsers> list = users.Select(n => new jUsers
                {
                    id = n.user_id,
                    name = n.user_name,
                    img = n.user_img,
                    email = n.user_email,
                    pass = n.user_pass,
                    coin = n.user_coin,
                    code = n.user_code,
                    token = Guid.NewGuid().ToString(),
                    datecreate = n.user_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.user_update.Value.ToString("yyyy-MM-dd"),
                    datelogin = n.user_datelogin.Value.ToString("yyyy-MM-dd"),
                    active = n.user_active,
                    bin = n.user_bin,
                    option = n.user_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        // Option
        public JsonResult OptionUser(int? id)
        {
            var dao = new UsersDAO();
            if (dao.Option(id))
            {
                // Giá trị Angular
                List<Users> users = db.Users.Where(n => n.user_bin == false).OrderByDescending(n => n.user_datecreate).ToList();
                // Tên biến
                List<jUsers> list = users.Select(n => new jUsers
                {
                    id = n.user_id,
                    name = n.user_name,
                    img = n.user_img,
                    email = n.user_email,
                    pass = n.user_pass,
                    coin = n.user_coin,
                    code = n.user_code,
                    token = Guid.NewGuid().ToString(),
                    datecreate = n.user_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.user_update.Value.ToString("yyyy-MM-dd"),
                    datelogin = n.user_datelogin.Value.ToString("yyyy-MM-dd"),
                    active = n.user_active,
                    bin = n.user_bin,
                    option = n.user_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        // Bin
        public JsonResult BinUser(int? id)
        {
            var dao = new UsersDAO();
            if (dao.Bin(id))
            {
                // Giá trị Angular
                List<Users> users = db.Users.Where(n => n.user_bin == false).OrderByDescending(n => n.user_datecreate).ToList();
                // Tên biến
                List<jUsers> list = users.Select(n => new jUsers
                {
                    id = n.user_id,
                    name = n.user_name,
                    img = n.user_img,
                    email = n.user_email,
                    pass = n.user_pass,
                    coin = n.user_coin,
                    code = n.user_code,
                    token = Guid.NewGuid().ToString(),
                    datecreate = n.user_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.user_update.Value.ToString("yyyy-MM-dd"),
                    datelogin = n.user_datelogin.Value.ToString("yyyy-MM-dd"),
                    active = n.user_active,
                    bin = n.user_bin,
                    option = n.user_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        public ActionResult IndexBin()
        {
            return View(db.Users.Where(n => n.user_bin == true).ToList());
        }

        // Restore
        public JsonResult RestoreUser(int? id)
        {
            var dao = new UsersDAO();
            if (dao.Restore(id))
            {
                // Giá trị Angular
                List<Users> users = db.Users.Where(n => n.user_bin == true).OrderByDescending(n => n.user_datecreate).ToList();
                // Tên biến
                List<jUsers> list = users.Select(n => new jUsers
                {
                    id = n.user_id,
                    name = n.user_name,
                    img = n.user_img,
                    email = n.user_email,
                    pass = n.user_pass,
                    coin = n.user_coin,
                    code = n.user_code,
                    token = Guid.NewGuid().ToString(),
                    datecreate = n.user_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.user_update.Value.ToString("yyyy-MM-dd"),
                    datelogin = n.user_datelogin.Value.ToString("yyyy-MM-dd"),
                    active = n.user_active,
                    bin = n.user_bin,
                    option = n.user_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        // Delete
        public JsonResult DeleteUser(int? id)
        {
            var dao = new UsersDAO();
            if (dao.Delete(id))
            {
                // Giá trị Angular
                List<Users> users = db.Users.Where(n => n.user_bin == true).OrderByDescending(n => n.user_datecreate).ToList();
                // Tên biến
                List<jUsers> list = users.Select(n => new jUsers
                {
                    id = n.user_id,
                    name = n.user_name,
                    img = n.user_img,
                    email = n.user_email,
                    pass = n.user_pass,
                    coin = n.user_coin,
                    code = n.user_code,
                    token = Guid.NewGuid().ToString(),
                    datecreate = n.user_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.user_update.Value.ToString("yyyy-MM-dd"),
                    datelogin = n.user_datelogin.Value.ToString("yyyy-MM-dd"),
                    active = n.user_active,
                    bin = n.user_bin,
                    option = n.user_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }
    }
}