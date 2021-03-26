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
    public class Programming_KnowledgesAdminController : Controller
    {
        // GET: Admin/Programming_KnowledgesAdmin

        //DataShareCodeEntities db = new DataShareCodeEntities();

        //public ActionResult Index()
        //{
        //    return View(db.Programming_Knowledges.Where(n => n.pk_bin == false).ToList());
        //}

        //// Create
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult CreatePK(Programming_Knowledges pk, HttpPostedFileBase IMG)
        //{
        //    var pk1 = Guid.NewGuid().ToString();
        //    var addimg = new ImagesController();

        //    pk.pk_active = true;
        //    pk.pk_option = true;
        //    pk.pk_bin = false;

        //    if (IMG == null)
        //    {
        //        pk.pk_img = "notimg.png";
        //    }
        //    else
        //    {
        //        addimg.AddImages(IMG, Common.Links.IMG_PKS, pk1);
        //        pk.pk_img = pk1 + IMG.FileName;
        //    }

        //    var dao = new PKDAO();
        //    if (dao.Create(pk))
        //    {
        //        return Redirect("/Admin/Programming_KnowledgesAdmin/Index");
        //    }
        //    return Redirect(Common.Links.NOT_404);
        //}

        //// Create
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult EditPK(Programming_Knowledges pk, HttpPostedFileBase IMG)
        //{
        //    var pk1 = Guid.NewGuid().ToString();
        //    var addimg = new ImagesController();

        //    pk.pk_active = true;
        //    pk.pk_option = true;
        //    pk.pk_bin = false;

        //    Programming_Knowledges PK = db.Programming_Knowledges.Find(pk.pk_id);

        //    if (IMG == null)
        //    {
        //        pk.pk_img = PK.pk_img;
        //    }
        //    else
        //    {
        //        addimg.AddImages(IMG, Common.Links.IMG_PKS, pk1);
        //        pk.pk_img = pk1 + IMG.FileName;
        //    }

        //    var dao = new PKDAO();
        //    if (dao.Edit(pk))
        //    {
        //        return Redirect("/Admin/Programming_KnowledgesAdmin/Index");
        //    }
        //    return Redirect(Common.Links.NOT_404);
        //}

        //// Active
        //public JsonResult ActivePK(int? id)
        //{
        //    var dao = new PKDAO();
        //    if (dao.Active(id))
        //    {
        //        // Giá trị Angular
        //        List<Programming_Knowledges> pk = db.Programming_Knowledges.Where(n => n.pk_bin == false).OrderByDescending(n => n.pk_datecreate).ToList();
        //        // Tên biến
        //        List<jPK> list = pk.Select(n => new jPK
        //        {
        //            id = n.pk_id,
        //            name = n.pk_name,
        //            img = n.pk_img,
        //            content = n.pk_content,
        //            datecreate = n.pk_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.pk_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.pk_active,
        //            bin = n.pk_bin,
        //            option = n.pk_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}

        //// Option
        //public JsonResult OptionPK(int? id)
        //{
        //    var dao = new PKDAO();
        //    if (dao.Option(id))
        //    {
        //        // Giá trị Angular
        //        List<Programming_Knowledges> pk = db.Programming_Knowledges.Where(n => n.pk_bin == false).OrderByDescending(n => n.pk_datecreate).ToList();
        //        // Tên biến
        //        List<jPK> list = pk.Select(n => new jPK
        //        {
        //            id = n.pk_id,
        //            name = n.pk_name,
        //            img = n.pk_img,
        //            content = n.pk_content,
        //            datecreate = n.pk_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.pk_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.pk_active,
        //            bin = n.pk_bin,
        //            option = n.pk_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}

        //// Bin
        //public JsonResult BinPK(int? id)
        //{
        //    var dao = new PKDAO();
        //    if (dao.Bin(id))
        //    {
        //        // Giá trị Angular
        //        List<Programming_Knowledges> pk = db.Programming_Knowledges.Where(n => n.pk_bin == false).OrderByDescending(n => n.pk_datecreate).ToList();
        //        // Tên biến
        //        List<jPK> list = pk.Select(n => new jPK
        //        {
        //            id = n.pk_id,
        //            name = n.pk_name,
        //            img = n.pk_img,
        //            content = n.pk_content,
        //            datecreate = n.pk_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.pk_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.pk_active,
        //            bin = n.pk_bin,
        //            option = n.pk_option
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
        //    return View(db.Programming_Knowledges.Where(n => n.pk_bin == true).ToList());
        //}

        //// Restore
        //public JsonResult RestorePK(int? id)
        //{
        //    var dao = new PKDAO();
        //    if (dao.Restore(id))
        //    {
        //        // Giá trị Angular
        //        List<Programming_Knowledges> pk = db.Programming_Knowledges.Where(n => n.pk_bin == true).OrderByDescending(n => n.pk_datecreate).ToList();
        //        // Tên biến
        //        List<jPK> list = pk.Select(n => new jPK
        //        {
        //            id = n.pk_id,
        //            name = n.pk_name,
        //            img = n.pk_img,
        //            content = n.pk_content,
        //            datecreate = n.pk_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.pk_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.pk_active,
        //            bin = n.pk_bin,
        //            option = n.pk_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}

        //// Delete
        //public JsonResult DeletePK(int? id)
        //{
        //    var dao = new PKDAO();
        //    if (dao.Delete(id))
        //    {
        //        // Giá trị Angular
        //        List<Programming_Knowledges> pk = db.Programming_Knowledges.Where(n => n.pk_bin == true).OrderByDescending(n => n.pk_datecreate).ToList();
        //        // Tên biến
        //        List<jPK> list = pk.Select(n => new jPK
        //        {
        //            id = n.pk_id,
        //            name = n.pk_name,
        //            img = n.pk_img,
        //            content = n.pk_content,
        //            datecreate = n.pk_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.pk_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.pk_active,
        //            bin = n.pk_bin,
        //            option = n.pk_option
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