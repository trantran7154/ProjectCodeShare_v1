using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class JsonAdminController : Controller
    {
        // GET: Admin/JsonAdmin
        DataShareCodeEntities db = new DataShareCodeEntities();
        public JsonResult Codes()
        {
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
    }
}