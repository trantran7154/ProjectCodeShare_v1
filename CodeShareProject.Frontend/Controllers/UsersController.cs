using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;
using CodeShare.Model.DAO;
using CodeShare.Model;
using CodeShare.Frontend.Models;
using CodeShare.Frontend.Functions;

namespace CodeShare.Frontend.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users

        DataShareCodeEntities db = new DataShareCodeEntities();
        UsersDAO usersDAO = new UsersDAO();

        public ActionResult Index()
        {
            return View();
        }

        // Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            String sEmail = f["user_email"].ToString();
            String sPass = f["user_pass"].ToString();

            Users users = db.Users.Where(n => n.user_option == true).SingleOrDefault(n => n.user_email == sEmail && n.user_pass == sPass);
           
            if (users != null)
            {
                HttpCookie cookie = new HttpCookie("user_id", users.user_id.ToString());
                cookie.Expires.AddDays(10);
                Response.Cookies.Set(cookie);
                return Redirect("/");
            }
            else
            {
                ViewBag.Check = "Sai tài khoản hoặc mật khẩu!";
            }
            return View(users);
        }

        // SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Users users, FormCollection f)
        {
            String sEmail = f["user_email"].ToString();

            if (sEmail != null)
            {
                users.user_img = "notimg.png";
                users.user_datelogin = DateTime.Now;
                users.user_active = true;
                users.user_bin = false;
                users.user_option = true;
                users.user_token = Guid.NewGuid().ToString();

                var dao = new UsersDAO();
                if (dao.Create(users))
                {
                    return RedirectToAction("CreateCode", new { id = users.user_id });
                }
            }
            else
            {
                ViewBag.Check = "Email đã tồn tại!";
            }
            return View(users);
        }

        public RedirectResult CreateCode(int? id)
        {
            Users user = db.Users.Find(id);

            user.user_code = "#COD-" + id;

            db.SaveChanges();

            HttpCookie httpCookie = new HttpCookie("user_id", id.ToString());
            httpCookie.Expires.AddDays(10);
            Response.Cookies.Set(httpCookie);

            return Redirect("/");
        }

        // SignOut
        public ActionResult LogOut()
        {
            HttpCookie cookie = Request.Cookies["user_id"];
            cookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Set(cookie);

            return Redirect("/");
        }
        public ActionResult Info()
        {
            FunctionsController functions = new FunctionsController();
            var cookie = functions.CookieID();
            if(cookie == null)
            {
                return RedirectToAction("Login");
            }

            return View(cookie);
        }

        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Users users, HttpPostedFileBase IMG)
        {
            if (ModelState.IsValid)
            {
                ImagesController images = new ImagesController();
                images.AddImages(IMG, "Users", Guid.NewGuid().ToString());
                usersDAO.Edit(users);
                return RedirectToAction("Info");
            }
            return View(users);
        }

        public JsonResult ChangeOption(int ? id)
        {
            HttpCookie httpCookie = new HttpCookie("user_id", id.ToString());
            httpCookie.Expires.AddDays(10);
            Response.Cookies.Set(httpCookie);

            var dao = new UsersDAO();
            dao.Option(id);
            return Json(JsonRequestBehavior.AllowGet);
        }
        
    }
}