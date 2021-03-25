using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;
using CodeShare.Frontend.Functions;
using CodeShare.Frontend.Models;

namespace CodeShare.Frontend.Controllers
{
    public class JsonController : Controller
    {
        DataShareCodeEntities db = new DataShareCodeEntities();
        // GET: Json
        public ActionResult Index()
        {
            return View();
        }
        //Tra ve nguoi dung
        public JsonResult Users()
        {
            var co = new FunctionsController();
            var id = co.CookieID();
            List<Users> users = db.Users.Where(n => n.user_id == id.user_id).ToList();
            List<jUsers> list = users.Select(n => new jUsers
            {
                active = n.user_active,
                bin = n.user_bin,
                code = n.user_code,
                coin = n.user_coin,
                datelogin = n.user_datelogin.ToString(),
                datecreate = n.user_datecreate.ToString(),
                email = n.user_email,
                id = n.user_id,
                img = n.user_img,
                name = n.user_name,
                option = n.user_option,
                pass = n.user_pass,
                token = n.user_token,
                update = n.user_update.ToString(),
                sex = n.user_sex,
                phone = n.user_phone,
                favorite = n .user_favorite,
                codefavorite = n.user_codefavorite,
                dateofbirth = n.user_dateofbirth.Value.ToShortDateString()

            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //Danh sách code
        public JsonResult Codes()
        {
            var co = new FunctionsController();
            var id = co.CookieID();
            List<Codes> codes = db.Codes.Where(n => n.user_id == id.user_id).ToList();
            List<jCodes> list = codes.Select(n => new jCodes
            {
                active = n.code_active,
                banner_id = n.banner_id,
                bin = n.code_bin,
                browser_demo = n.code_browser_demo,
                browser_downoad = n.code_browser_downoad,
                browser_error = n.code_browser_error,
                browser_quality = n.code_browser_quality,
                capacity = n.code_capacity,
                coin = n.code_coin,
                datecreate = n.code_datecreate.ToString(),
                demo = n.code_demo,
                description = n.code_description,
                down = n.code_down,
                form_id = n.form_id,
                id = (int)n.form_id,
                img = n.code_img,
                introduce = n.code_introduce,
                link = n.code_link,
                name = n.code_name,
                option = n.code_option,
                point_quality = n.code_point_quality,
                point_refer = n.code_point_refer,
                update = n.code_update.ToString(),
                user_id = n.user_id,
                user_name = n.code_name,
                view = (int)n.code_view

            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}