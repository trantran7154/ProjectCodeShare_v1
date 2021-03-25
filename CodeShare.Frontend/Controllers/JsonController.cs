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
            List<User> users = db.Users.Where(n => n.user_id == id.user_id).ToList();
            List<jUsers> list = users.Select(n => new jUsers
            {
                active = (int)n.user_active,
                birth = n.user_birth.Value.ToLongDateString(),
                code = n.user_code,
                coin = (int)n.user_coin,
                datecreate = n.user_datecreate.Value.ToLongDateString(),
                dateupdate = n.user_dateupdate.Value.ToLongDateString(),
                del = n.user_del,
                email = n.user_email,
                fa = n.user_fa,
                facode = n.user_facode,
                id = n.user_id,
                name = n.user_name,
                none = n.user_none,
                option = n.user_option,
                phone = n.user_phone,
                role = (int)n.user_role,
                sex = n.user_sex,
                token = n.user_token,
                view = (int)n.user_view
            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //Danh sách code
        public JsonResult Codes()
        {
            var co = new FunctionsController();
            var id = co.CookieID();
            List<Code> codes = db.Codes.Where(n => n.user_id == id.user_id).ToList();
            List<jCodes> list = codes.Select(n => new jCodes
            {
                active = (int)n.code_active,
                code = n.code_code,
                coin = (int)n.code_coin,
                datecreate = n.code_datecreate.ToString(),
                dateupdate = n.code_dateupdate.ToString(),
                del = n.code_del,
                des = n.code_des,
                disk = (int)n.code_disk,
                id = n.code_id,
                id_cate = (int)n.category_id,
                id_us = (int)n.user_id,
                info = n.code_info,
                linkdemo = n.code_linkdemo,
                linkdown = n.code_linkdown,
                option = n.code_option,
                pass = n.code_pass,
                setting = n.code_setting,
                tag = n.code_tag,
                title = n.code_title,
                view = (int)n.code_view,
                viewdown = (int)n.code_viewdown,
                img = n.code_img

            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}