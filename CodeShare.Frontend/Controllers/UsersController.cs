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
using CodeShare.Common;
using System.Web.Helpers;

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
            if (function.CookieID() != null)
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(ViewLogin login)
        {

            if (ModelState.IsValid)
            {
                int status = usersDAO.Login(login.Email, login.Password);
                switch (status)
                {
                    case 1:
                        var user = db.Users.FirstOrDefault(t => t.user_email == login.Email && t.user_pass == login.Password);
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
        [HttpPost]
        public ActionResult LoginModal(ViewLogin login)
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
                        var user = db.Users.FirstOrDefault(t => t.user_email == login.Email && t.user_pass == login.Password);
                        HttpCookie cookie = new HttpCookie("user_id", user.user_id.ToString());
                        cookie.Expires.AddDays(10);
                        Response.Cookies.Set(cookie);
                        return Redirect(Request.UrlReferrer.ToString());
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
            if (function.CookieID() != null)
            {
                return Redirect("/");
            }
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
                    user_name = register.DisplayName,
                    user_img = "notimg.png"
                };
                usersDAO.Add(user);

                var user1 = db.Users.FirstOrDefault(t => t.user_email == register.Email && t.user_pass == register.Password);
                HttpCookie cookie = new HttpCookie("user_id", user1.user_id.ToString());
                cookie.Expires.AddDays(10);
                Response.Cookies.Set(cookie);
                return RedirectToAction("Info");
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

        public ActionResult ResetPassword(ViewResetPasword resetPasword)
        {
            FunctionsController functions = new FunctionsController();
            var cookie = functions.CookieID();
            if (cookie == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if (cookie.user_pass == resetPasword.OldPassword)
                {
                    usersDAO.ResetPassword(cookie.user_id, resetPasword.NewPassword);
                    ViewBag.Check = "Mật khẩu đã được cập nhật!";
                }
                return View(resetPasword);
            }
        }

        //Sửa ảnh
        public ActionResult EditImages(HttpPostedFileBase IMG)
        {
            var coo = new FunctionsController();
            var id = coo.CookieID();
            User user = db.Users.Find(id.user_id);

            if (IMG == null)
            {
                user.user_img = id.user_img;
            }
            else
            {
                var code = Guid.NewGuid().ToString();
                var img = new ImagesController();
                var imgd = img.UpLoadImages(IMG,user.user_img ,Common.Links.IMG_USERS);
                user.user_img = imgd;
            }

            db.SaveChanges();
            return Redirect("/Users/Info");
        }
        //Sửa cho tất cả
        public JsonResult EditAll(string name, Nullable<bool> sex, string phone, string fa)
        {
            var co = new FunctionsController();
            var id = co.CookieID();

            User user = db.Users.Find(id.user_id);

            if(name != null)
            {
                user.user_name = name;
            }
            else if(sex != null)
            {
                user.user_sex = sex;
            }
            else if (phone != null)
            {
                user.user_phone = phone;
            }
            else if(fa != null)
            {
                user.user_fa = fa;
            }
            else
            {

            }
            db.SaveChanges();

            var list = from item in db.Users
                       where item.user_id == id.user_id
                       select new
                       {
                           id = item.user_id,
                           birth = item.user_birth,
                           name = item.user_name,
                           sex = item.user_sex,
                           phone = item.user_phone,
                           fa = item.user_fa
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //Yêu thích code
        public JsonResult FaCode(int ? id)
        {
            var co = new FunctionsController();
            var idus = co.CookieID();

            Group group = new Group()
            {
                user_id = idus.user_id,
                language_id = id,
                group_item = Common.Common.ITEM_LANGUAGE_USER
                
            };
            db.Groups.Add(group);
            db.SaveChanges();

            var list = from item in db.Groups
                       where item.group_item == Common.Common.ITEM_LANGUAGE_USER && item.user_id == idus.user_id
                       select new
                       {
                           id = item.language_id,
                           idus = item.user_id,
                           item = item.group_item,
                           name = item.Language.language_name
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Quên mật khẩu
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPassword fp)
        {
            try
            {
                // Máy chủ gmail
                WebMail.SmtpServer = "smtp.gmail.com";
                // Cổng
                WebMail.SmtpPort = 465;
                WebMail.SmtpUseDefaultCredentials = true;
                //Gửi gmail với giao thức bảo mật
                WebMail.EnableSsl = true;
                //Tài khoản dùng để đăng nhập vào gmail để gửi
                WebMail.UserName = "vuongbaot1905@gmail.com";
                WebMail.Password = "tran1905";
                // Nội dung gửi
                WebMail.From = "vuongbaot1905@gmail.com";
                User user = db.Users.SingleOrDefault(n => n.user_email == fp.ConfirmationEmail);
                fp.Theme = "Xác nhận mật khẩu Web";
                fp.Content = "Xác Nhận: https://localhost:44327/Users/ChangePassword/" + user.user_id + "&Token=" + user.user_token;
                //Gửi gmail
                WebMail.Send(to: fp.ConfirmationEmail, subject: fp.Theme, body: fp.Content, cc: fp.Cc, bcc: fp.Bcc, isBodyHtml: true);
                ViewBag.Sucess = "Gửi thành công! Vui lòng kiểm tra email/gmail.";
            }
            catch (Exception)
            {
                ViewBag.Fail = "Gửi gmail thất bại! Vui lòng thử lại.";
            }
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}