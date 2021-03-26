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

        CodeShareDataEntities db = new CodeShareDataEntities();

        public ActionResult Index()
        {
            return View(db.Denominations.Where(n => n.denomination_bin == false).ToList());
        }

        // Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateDenomination(Denominations denominations)
        {
            denominations.denomination_bin = false;
            denominations.denomination_option = true;

            var dao = new DenominationsDAO();
            if (dao.Create(denominations))
            {
                return Redirect("/Admin/DenominationsAdmin/Index");
            }
            else
            {
                return Redirect(Common.Links.NOT_404);
            }
        }

        // Edit
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditDenomination(Denominations denominations)
        {
            Denominations denominations1 = db.Denominations.Find(denominations.denomination_id);

            denominations.denomination_bin = denominations1.denomination_bin;
            denominations.denomination_active = denominations1.denomination_active;
            denominations.denomination_option = denominations1.denomination_option;
            denominations.denomination_datecreate = denominations1.denomination_datecreate;

            var dao = new DenominationsDAO();
            if (dao.Edit(denominations))
            {
                return Redirect("/Admin/DenominationsAdmin/Index");
            }
            else
            {
                return Redirect(Common.Links.NOT_404);
            }
        }

        // Active
        public JsonResult ActiveDenomination(int? id)
        {
            var dao = new DenominationsDAO();
            if (dao.Active(id))
            {
                // Giá trị Angular
                List<Denominations> denominations = db.Denominations.Where(n => n.denomination_bin == false).OrderByDescending(n => n.denomination_datecreate).ToList();
                // Tên biến
                List<jDenominations> list = denominations.Select(n => new jDenominations
                {
                    id = n.denomination_id,
                    price = n.denomination_price,
                    coin = n.denomination_coin,
                    datecreate = n.denomination_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.denomination_update.Value.ToString("yyyy-MM-dd"),
                    active = n.denomination_active,
                    bin = n.denomination_bin,
                    option = n.denomination_option,
                    content = n.denomination_content
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        // Option
        public JsonResult OptionDenomination(int? id)
        {
            var dao = new DenominationsDAO();
            if (dao.Option(id))
            {
                // Giá trị Angular
                List<Denominations> denominations = db.Denominations.Where(n => n.denomination_bin == false).OrderByDescending(n => n.denomination_datecreate).ToList();
                // Tên biến
                List<jDenominations> list = denominations.Select(n => new jDenominations
                {
                    id = n.denomination_id,
                    price = n.denomination_price,
                    coin = n.denomination_coin,
                    datecreate = n.denomination_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.denomination_update.Value.ToString("yyyy-MM-dd"),
                    active = n.denomination_active,
                    bin = n.denomination_bin,
                    option = n.denomination_option,
                    content = n.denomination_content
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        // Bin
        public JsonResult BinDenomination(int? id)
        {
            var dao = new DenominationsDAO();
            if (dao.Bin(id))
            {
                // Giá trị Angular
                List<Denominations> denominations = db.Denominations.Where(n => n.denomination_bin == false).OrderByDescending(n => n.denomination_datecreate).ToList();
                // Tên biến
                List<jDenominations> list = denominations.Select(n => new jDenominations
                {
                    id = n.denomination_id,
                    price = n.denomination_price,
                    coin = n.denomination_coin,
                    datecreate = n.denomination_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.denomination_update.Value.ToString("yyyy-MM-dd"),
                    active = n.denomination_active,
                    bin = n.denomination_bin,
                    option = n.denomination_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        public ActionResult IndexBin()
        {
            return View(db.Denominations.Where(n => n.denomination_bin == false).ToList());
        }

        // Restore
        public JsonResult RestoreDenomination(int? id)
        {
            var dao = new DenominationsDAO();
            if (dao.Restore(id))
            {
                // Giá trị Angular
                List<Denominations> denominations = db.Denominations.Where(n => n.denomination_bin == true).OrderByDescending(n => n.denomination_datecreate).ToList();
                // Tên biến
                List<jDenominations> list = denominations.Select(n => new jDenominations
                {
                    id = n.denomination_id,
                    price = n.denomination_price,
                    coin = n.denomination_coin,
                    datecreate = n.denomination_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.denomination_update.Value.ToString("yyyy-MM-dd"),
                    active = n.denomination_active,
                    bin = n.denomination_bin,
                    option = n.denomination_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        // Delete
        public JsonResult DeleteDenomination(int? id)
        {
            var dao = new DenominationsDAO();
            if (dao.Delete(id))
            {
                // Giá trị Angular
                List<Denominations> denominations = db.Denominations.Where(n => n.denomination_bin == true).OrderByDescending(n => n.denomination_datecreate).ToList();
                // Tên biến
                List<jDenominations> list = denominations.Select(n => new jDenominations
                {
                    id = n.denomination_id,
                    price = n.denomination_price,
                    coin = n.denomination_coin,
                    datecreate = n.denomination_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.denomination_update.Value.ToString("yyyy-MM-dd"),
                    active = n.denomination_active,
                    bin = n.denomination_bin,
                    option = n.denomination_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }
    }
}