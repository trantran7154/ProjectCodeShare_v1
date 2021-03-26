using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model;
using CodeShare.Model.DAO;
using CodeShare.Model.EF;
using CodeShare.Common;
using CodeShare.Frontend.Models;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class DenominationsAdminController : Controller
    {
        // GET: Admin/DenominationsAdmin

        //DataShareCodeEntities db = new DataShareCodeEntities();

        //public ActionResult Index()
        //{
        //    return View(db.TakePrices.ToList());
        //}

        //// Create
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult CreateDenomination(TakePrice denominations)
        //{
        //    denominations.tp_active = 1;

        //    var dao = new TakePricesDao();
        //    if (dao.Create(denominations))
        //    {
        //        return Redirect("/Admin/DenominationsAdmin/Index");
        //    }
        //    else
        //    {
        //        return Redirect(Common.Links.NOT_404);
        //    }
        //}

        //// Edit
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult EditDenomination(TakePrice denominations)
        //{
        //    TakePrice denominations1 = db.TakePrices.Find(denominations.tp_id);

        //    denominations.tp_active = denominations1.tp_active;
        //    denominations.tp_datecreate = denominations1.tp_datecreate;

        //    var dao = new TakePricesDao();
        //    if (dao.Edit(denominations))
        //    {
        //        return Redirect("/Admin/DenominationsAdmin/Index");
        //    }
        //    else
        //    {
        //        return Redirect(Common.Links.NOT_404);
        //    }
        //}

        //// Active
        //public JsonResult ActiveDenomination(int? id)
        //{
        //    var dao = new TakePricesDao();
        //    if (dao.Active(id))
        //    {
        //        // Giá trị Angular
        //        List<TakePrice> denominations = db.TakePrices.OrderByDescending(n => n.tp_datecreate).ToList();
        //        // Tên biến
        //        List<jTakePrices> list = denominations.Select(n => new jTakePrices
        //        {
        //            active = (int)n.pakage_active,
        //            coin = (int)n.pakage_coin,
        //            id = n.pakege_id,
        //            money = n.pakage_money
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Option
        //public JsonResult OptionDenomination(int? id)
        //{
        //    var dao = new DenominationsDAO();
        //    if (dao.Option(id))
        //    {
        //        // Giá trị Angular
        //        List<Denominations> denominations = db.Denominations.Where(n => n.denomination_bin == false).OrderByDescending(n => n.denomination_datecreate).ToList();
        //        // Tên biến
        //        List<jDenominations> list = denominations.Select(n => new jDenominations
        //        {
        //            id = n.denomination_id,
        //            price = n.denomination_price,
        //            coin = n.denomination_coin,
        //            datecreate = n.denomination_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.denomination_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.denomination_active,
        //            bin = n.denomination_bin,
        //            option = n.denomination_option,
        //            content = n.denomination_content
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Bin
        //public JsonResult BinDenomination(int? id)
        //{
        //    var dao = new DenominationsDAO();
        //    if (dao.Bin(id))
        //    {
        //        // Giá trị Angular
        //        List<Denominations> denominations = db.Denominations.Where(n => n.denomination_bin == false).OrderByDescending(n => n.denomination_datecreate).ToList();
        //        // Tên biến
        //        List<jDenominations> list = denominations.Select(n => new jDenominations
        //        {
        //            id = n.denomination_id,
        //            price = n.denomination_price,
        //            coin = n.denomination_coin,
        //            datecreate = n.denomination_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.denomination_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.denomination_active,
        //            bin = n.denomination_bin,
        //            option = n.denomination_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //public ActionResult IndexBin()
        //{
        //    return View(db.Denominations.Where(n => n.denomination_bin == false).ToList());
        //}

        //// Restore
        //public JsonResult RestoreDenomination(int? id)
        //{
        //    var dao = new DenominationsDAO();
        //    if (dao.Restore(id))
        //    {
        //        // Giá trị Angular
        //        List<Denominations> denominations = db.Denominations.Where(n => n.denomination_bin == true).OrderByDescending(n => n.denomination_datecreate).ToList();
        //        // Tên biến
        //        List<jDenominations> list = denominations.Select(n => new jDenominations
        //        {
        //            id = n.denomination_id,
        //            price = n.denomination_price,
        //            coin = n.denomination_coin,
        //            datecreate = n.denomination_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.denomination_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.denomination_active,
        //            bin = n.denomination_bin,
        //            option = n.denomination_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Delete
        //public JsonResult DeleteDenomination(int? id)
        //{
        //    var dao = new DenominationsDAO();
        //    if (dao.Delete(id))
        //    {
        //        // Giá trị Angular
        //        List<Denominations> denominations = db.Denominations.Where(n => n.denomination_bin == true).OrderByDescending(n => n.denomination_datecreate).ToList();
        //        // Tên biến
        //        List<jDenominations> list = denominations.Select(n => new jDenominations
        //        {
        //            id = n.denomination_id,
        //            price = n.denomination_price,
        //            coin = n.denomination_coin,
        //            datecreate = n.denomination_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.denomination_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.denomination_active,
        //            bin = n.denomination_bin,
        //            option = n.denomination_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}
    }
}