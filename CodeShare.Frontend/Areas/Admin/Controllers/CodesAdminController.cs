using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;
using CodeShare.Model.DAO;
using CodeShare.Frontend.Models;
using CodeShare.Frontend.Functions;
using CodeShare.Common;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class CodesAdminController : Controller
    {
        // GET: Admin/CodesAdmin
        DataShareCodeEntities db = new DataShareCodeEntities();
        public ActionResult Index()
        {
            return View(db.Codes.Where(n => n.code_del == false).ToList());
        }

        //// Create
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult CreateCode(Code codes,HttpPostedFileBase IMG, string[] tags)
        //{
        //    var code = Guid.NewGuid().ToString();
        //    var addimg = new ImagesController();

        //    codes.code_del = false;

        //    codes.code_active = 1;
        //    codes.code_option = true;

        //    codes.code_view = 1;

        //    if (IMG == null)
        //    {
        //        codes.code_img = "notimg.png";
        //    }
        //    else
        //    {
        //        addimg.AddImages(IMG,Common.Links.IMG_CODES,code);
        //        codes.code_img = code + IMG.FileName;
        //    }

        //    var dao = new CodesDao();
        //    if(dao.Create(codes, tags))
        //    {
        //        return Redirect("/Admin/CodesAdmin/Index");
        //    }
        //    else
        //    {
        //        return Redirect(Common.Links.NOT_404);
        //    }
        //}

        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult EditCode(Code codes, HttpPostedFileBase IMG, string[] tags)
        //{
        //    var code = Guid.NewGuid().ToString();
        //    var addimg = new ImagesController();

        //    codes.code_del = false;

        //    codes.code_active = 1;
        //    codes.code_option = true;

        //    codes.code_view = 1;

        //    Code codes1 = db.Codes.Find(codes.code_id);

        //    if (IMG == null)
        //    {
        //        codes.code_img = codes1.code_img;
        //    }
        //    else
        //    {

        //        addimg.AddImages(IMG, Common.Links.IMG_CODES, code);
        //        codes.code_img = code + IMG.FileName;
        //    }

        //    var dao = new CodesDao();
        //    if (dao.Edit(codes, tags))
        //    {
        //        return Redirect("/Admin/CodesAdmin/Index");
        //    }
        //    else
        //    {
        //        return Redirect(Common.Links.NOT_404);
        //    }
        //}

        //// Active
        //public JsonResult ActiveCode(int? id, int status = 2)
        //{
        //    var dao = new CodesDao();
        //    if (dao.Active(id, status))
        //    {

        //        // Giá trị Angular
        //        List<Code> codes = db.Codes.Where(n => n.code_del == false).OrderByDescending(n => n.code_datecreate).ToList();
        //        // Tên biến
        //        List<jCodes> list = codes.Select(n => new jCodes
        //        {
        //            id = n.code_id,
        //            active = (int)n.code_active,
        //            code = n.code_code.ToString(),
        //            coin = (int)n.code_coin,
        //            datecreate = n.code_datecreate.Value.ToString("yyyy-MM-dd"),
        //            dateupdate = n.code_dateupdate.Value.ToString("yyyy-MM-dd"),
        //            del = n.code_del,
        //            des = n.code_des,
        //            disk = (int)n.code_disk,
        //            id_cate = (int)n.category_id,
        //            id_us = (int)n.user_id,
        //            img = n.code_img.ToString(),
        //            info = n.code_info.ToString(),
        //            linkdemo = n.code_linkdemo.ToString(),
        //            linkdown = n.code_linkdown.ToString(),
        //            option = n.code_option,
        //            pass = n.code_pass.ToString(),
        //            setting = n.code_setting.ToString(),
        //            tag = n.code_tag.ToString(),
        //            title = n.code_title.ToString(),
        //            view = (int)n.code_view,
        //            viewdown = (int)n.code_viewdown
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Option
        //public JsonResult OptionCode(int? id)
        //{
        //    var dao = new CodesDao();
        //    if (dao.Option(id))
        //    {

        //        // Giá trị Angular
        //        List<Code> codes = db.Codes.Where(n => n.code_del == false).OrderByDescending(n => n.code_datecreate).ToList();
        //        // Tên biến
        //        List<jCodes> list = codes.Select(n => new jCodes
        //        {
        //            id = n.code_id,
        //            active = (int)n.code_active,
        //            code = n.code_code.ToString(),
        //            coin = (int)n.code_coin,
        //            datecreate = n.code_datecreate.Value.ToString("yyyy-MM-dd"),
        //            dateupdate = n.code_dateupdate.Value.ToString("yyyy-MM-dd"),
        //            del = n.code_del,
        //            des = n.code_des,
        //            disk = (int)n.code_disk,
        //            id_cate = (int)n.category_id,
        //            id_us = (int)n.user_id,
        //            img = n.code_img.ToString(),
        //            info = n.code_info.ToString(),
        //            linkdemo = n.code_linkdemo.ToString(),
        //            linkdown = n.code_linkdown.ToString(),
        //            option = n.code_option,
        //            pass = n.code_pass.ToString(),
        //            setting = n.code_setting.ToString(),
        //            tag = n.code_tag.ToString(),
        //            title = n.code_title.ToString(),
        //            view = (int)n.code_view,
        //            viewdown = (int)n.code_viewdown
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Bin
        //public JsonResult BinCode(int? id)
        //{
        //    var dao = new CodesDao();
        //    if (dao.Bin(id))
        //    {

        //        // Giá trị Angular
        //        List<Code> codes = db.Codes.Where(n => n.code_del == false).OrderByDescending(n => n.code_datecreate).ToList();
        //        // Tên biến
        //        List<jCodes> list = codes.Select(n => new jCodes
        //        {
        //            id = n.code_id,
        //            active = (int)n.code_active,
        //            code = n.code_code.ToString(),
        //            coin = (int)n.code_coin,
        //            datecreate = n.code_datecreate.Value.ToString("yyyy-MM-dd"),
        //            dateupdate = n.code_dateupdate.Value.ToString("yyyy-MM-dd"),
        //            del = n.code_del,
        //            des = n.code_des,
        //            disk = (int)n.code_disk,
        //            id_cate = (int)n.category_id,
        //            id_us = (int)n.user_id,
        //            img = n.code_img.ToString(),
        //            info = n.code_info.ToString(),
        //            linkdemo = n.code_linkdemo.ToString(),
        //            linkdown = n.code_linkdown.ToString(),
        //            option = n.code_option,
        //            pass = n.code_pass.ToString(),
        //            setting = n.code_setting.ToString(),
        //            tag = n.code_tag.ToString(),
        //            title = n.code_title.ToString(),
        //            view = (int)n.code_view,
        //            viewdown = (int)n.code_viewdown
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //public ActionResult IndexBin()
        //{
        //    return View(db.Codes.Where(n => n.code_del == true).ToList());
        //}

        //// Restore
        //public JsonResult RestoreCode(int? id)
        //{
        //    var dao = new CodesDao();
        //    if (dao.Restore(id))
        //    {

        //        // Giá trị Angular
        //        List<Code> codes = db.Codes.Where(n => n.code_del == true).OrderByDescending(n => n.code_datecreate).ToList();
        //        // Tên biến
        //        List<jCodes> list = codes.Select(n => new jCodes
        //        {
        //            id = n.code_id,
        //            active = (int)n.code_active,
        //            code = n.code_code.ToString(),
        //            coin = (int)n.code_coin,
        //            datecreate = n.code_datecreate.Value.ToString("yyyy-MM-dd"),
        //            dateupdate = n.code_dateupdate.Value.ToString("yyyy-MM-dd"),
        //            del = n.code_del,
        //            des = n.code_des,
        //            disk = (int)n.code_disk,
        //            id_cate = (int)n.category_id,
        //            id_us = (int)n.user_id,
        //            img = n.code_img.ToString(),
        //            info = n.code_info.ToString(),
        //            linkdemo = n.code_linkdemo.ToString(),
        //            linkdown = n.code_linkdown.ToString(),
        //            option = n.code_option,
        //            pass = n.code_pass.ToString(),
        //            setting = n.code_setting.ToString(),
        //            tag = n.code_tag.ToString(),
        //            title = n.code_title.ToString(),
        //            view = (int)n.code_view,
        //            viewdown = (int)n.code_viewdown
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Delete
        //public JsonResult DeleteCode(int? id)
        //{
        //    var dao = new CodesDao();
        //    if (dao.Delete(id))
        //    {

        //        // Giá trị Angular
        //        List<Code> codes = db.Codes.Where(n => n.code_del == true).OrderByDescending(n => n.code_datecreate).ToList();
        //        // Tên biến
        //        List<jCodes> list = codes.Select(n => new jCodes
        //        {
        //            id = n.code_id,
        //            active = (int)n.code_active,
        //            code = n.code_code.ToString(),
        //            coin = (int)n.code_coin,
        //            datecreate = n.code_datecreate.Value.ToString("yyyy-MM-dd"),
        //            dateupdate = n.code_dateupdate.Value.ToString("yyyy-MM-dd"),
        //            del = n.code_del,
        //            des = n.code_des,
        //            disk = (int)n.code_disk,
        //            id_cate = (int)n.category_id,
        //            id_us = (int)n.user_id,
        //            img = n.code_img.ToString(),
        //            info = n.code_info.ToString(),
        //            linkdemo = n.code_linkdemo.ToString(),
        //            linkdown = n.code_linkdown.ToString(),
        //            option = n.code_option,
        //            pass = n.code_pass.ToString(),
        //            setting = n.code_setting.ToString(),
        //            tag = n.code_tag.ToString(),
        //            title = n.code_title.ToString(),
        //            view = (int)n.code_view,
        //            viewdown = (int)n.code_viewdown
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}
    }
}