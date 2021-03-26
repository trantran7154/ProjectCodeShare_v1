using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Frontend.Functions;
using CodeShare.Model;
using CodeShare.Model.EF;
using CodeShare.Model.DAO;
using CodeShare.Common;
using CodeShare.Frontend.Models;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class Knowledge_CategorysAdminController : Controller
    {
        // GET: Admin/Knowledge_CategorysAdmin

        //DataShareCodeEntities db = new DataShareCodeEntities();

        //public ActionResult Index()
        //{
        //    return View(db.Knowledge_Categorys.Where(n => n.kc_bin == false).ToList());
        //}

        //// Create
        //[HttpPost]
        //public ActionResult CreateKC(Knowledge_Categorys kc)
        //{
        //    kc.kc_active = true;
        //    kc.kc_option = true;
        //    kc.kc_bin = false;

        //    var dao = new KCDAO();
        //    if (dao.Create(kc))
        //    {
        //        return Redirect("/Admin/Knowledge_CategorysAdmin/Index");
        //    }
        //    return Redirect(Common.Links.NOT_404);
        //}

        //// Edit
        //[HttpPost]
        //public ActionResult EditKC(Knowledge_Categorys kc)
        //{
        //    Knowledge_Categorys knowledge_Categorys = db.Knowledge_Categorys.Find(kc.kc_id);

        //    kc.kc_active = knowledge_Categorys.kc_active;
        //    kc.kc_option = knowledge_Categorys.kc_option;
        //    kc.kc_bin = knowledge_Categorys.kc_bin;
        //    kc.kc_datecreate = knowledge_Categorys.kc_datecreate;

        //    var dao = new KCDAO();
        //    if (dao.Edit(kc))
        //    {
        //        return Redirect("/Admin/Knowledge_CategorysAdmin/Index");
        //    }
        //    return Redirect(Common.Links.NOT_404);
        //}

        //// Active
        //public JsonResult ActiveKC(int? id)
        //{
        //    var dao = new KCDAO(); 
        //    if (dao.Active(id))
        //    {
        //        // Giá trị Angular
        //        List<Knowledge_Categorys> kc = db.Knowledge_Categorys.Where(n => n.kc_bin == false).ToList();
        //        // Tên biến
        //        List<jKC> list = kc.Select(n => new jKC
        //        {
        //            id = n.kc_id,
        //            name = n.kc_name,
        //            datecreate = n.kc_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.kc_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.kc_active,
        //            bin = n.kc_bin,
        //            option = n.kc_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}

        //// Option
        //public JsonResult OptionKC(int? id)
        //{
        //    var dao = new KCDAO();
        //    if (dao.Option(id))
        //    {
        //        // Giá trị Angular
        //        List<Knowledge_Categorys> kc = db.Knowledge_Categorys.Where(n => n.kc_bin == false).ToList();
        //        // Tên biến
        //        List<jKC> list = kc.Select(n => new jKC
        //        {
        //            id = n.kc_id,
        //            name = n.kc_name,
        //            datecreate = n.kc_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.kc_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.kc_active,
        //            bin = n.kc_bin,
        //            option = n.kc_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}

        //// Bin
        //public JsonResult BinKC(int? id)
        //{
        //    var dao = new KCDAO();
        //    if (dao.Bin(id))
        //    {
        //        // Giá trị Angular
        //        List<Knowledge_Categorys> kc = db.Knowledge_Categorys.Where(n => n.kc_bin == false).ToList();
        //        // Tên biến
        //        List<jKC> list = kc.Select(n => new jKC
        //        {
        //            id = n.kc_id,
        //            name = n.kc_name,
        //            datecreate = n.kc_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.kc_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.kc_active,
        //            bin = n.kc_bin,
        //            option = n.kc_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}

        //public ActionResult IndexBin()
        //{
        //    return View(db.Knowledge_Categorys.Where(n => n.kc_bin == true).ToList());
        //}

        //// Restore
        //public JsonResult RestoreKC(int? id)
        //{
        //    var dao = new KCDAO();
        //    if (dao.Restore(id))
        //    {
        //        // Giá trị Angular
        //        List<Knowledge_Categorys> kc = db.Knowledge_Categorys.Where(n => n.kc_bin == true).ToList();
        //        // Tên biến
        //        List<jKC> list = kc.Select(n => new jKC
        //        {
        //            id = n.kc_id,
        //            name = n.kc_name,
        //            datecreate = n.kc_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.kc_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.kc_active,
        //            bin = n.kc_bin,
        //            option = n.kc_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}

        //// Delte
        //public JsonResult DeleteKC(int? id)
        //{
        //    var dao = new KCDAO();
        //    if (dao.Delete(id))
        //    {
        //        // Giá trị Angular
        //        List<Knowledge_Categorys> kc = db.Knowledge_Categorys.Where(n => n.kc_bin == true).ToList();
        //        // Tên biến
        //        List<jKC> list = kc.Select(n => new jKC
        //        {
        //            id = n.kc_id,
        //            name = n.kc_name,
        //            datecreate = n.kc_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.kc_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.kc_active,
        //            bin = n.kc_bin,
        //            option = n.kc_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}
    }
}