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
using CodeShare.Frontend.ViewModels;

namespace CodeShare.Frontend.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users

        DataShareCodeEntities db = new DataShareCodeEntities();
        UsersDao usersDAO = new UsersDao();
        FunctionsController function = new FunctionsController();

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
        public ActionResult Login(ViewLogin login)
        {
            if (function.CookieID() != null)
            {
                return Redirect("/");
            }
            if (ModelState.IsValid)
            {
                int status = usersDAO.Login(login.Email, login.Password);
                switch (status)
                {
                    case 1:
                        var user = db.Users.FirstOrDefault(t => t.user_email == login.Email);
                        HttpCookie cookie = new HttpCookie("user_id", user.user_id.ToString());
                        cookie.Expires.AddDays(10);
                        Response.Cookies.Set(cookie);
                        return Redirect("/");
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

        // SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(ViewRegister register)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.SingleOrDefault(t => t.user_email == register.Email) != null)
                {
                    TempData["noti_register"] = "Email đã tồn tại!";
                    return View(register);
                }
                var user = new User()
                {
                    user_email = register.Email,
                    user_pass = register.Password,
                    user_name = register.DisplayName
                };
                usersDAO.Add(user);

                return RedirectToAction("Login");
            }
            return View(register);
        }

        public RedirectResult CreateCode(int? id)
        {
            User user = db.Users.Find(id);

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
        public ActionResult Edit(User users, HttpPostedFileBase IMG)
        {
            if (ModelState.IsValid)
            {
               
            }
            return View(users);
        }

        public JsonResult ChangeOption(int ? id)
        {
            HttpCookie httpCookie = new HttpCookie("user_id", id.ToString());
            httpCookie.Expires.AddDays(10);
            Response.Cookies.Set(httpCookie);

            var dao = new UsersDao();
            
            return Json(JsonRequestBehavior.AllowGet);
        }
        
    }
}