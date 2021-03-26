using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;
using CodeShare.Model.DAO;
using CodeShare.Frontend.Models;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class BannersAdminController : Controller
    {
        private CodeShareDataEntities db = new CodeShareDataEntities(); 

        // GET: Admin/Banners
        public ActionResult Index()
        {
            return View(db.Banners.Where(n => n.banner_bin == false).ToList());
        }

        // Create
        [ValidateInput(false)]
        public ActionResult CreateBanner(Banners banners)
        {
            banners.banner_option = true;
            banners.banner_active = true;

            var dao = new BannersDAO();
            if (dao.Create(banners))
            {
                return Redirect("/Admin/BannersAdmin/Index");
            }

            return Redirect(Common.Links.NOT_404);
        }

        // Bin
        public JsonResult BinBanner(int? id)
        {
            var dao = new BannersDAO();
            if (dao.Bin(id))
            {
                // Giá trị Angular
                List<Banners> banners = db.Banners.Where(n => n.banner_bin == false).OrderByDescending(n => n.banner_datecreate).ToList();
                // Tẹn biến
                List<jBanners> list = banners.Select(n => new jBanners
                {
                    id = n.banner_id,
                    name = n.banner_name,
                    svg = n.banner_svg,
                    datecreate = n.banner_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.banner_update.Value.ToString("yyyy-MM-dd"),
                    active = n.banner_active,
                    bin = n.banner_bin,
                    option = n.banner_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        // Edit
        [ValidateInput(false)]
        public ActionResult EditBanner(Banners banners)
        {
            Banners banner = db.Banners.Find(banners.banner_id);

            banners.banner_datecreate = banner.banner_datecreate;
            banners.banner_bin = banner.banner_bin;
            banners.banner_active = banner.banner_active;
            banners.banner_option = banner.banner_option;

            var dao = new BannersDAO();
            if (dao.Edit(banners))
            {
                return Redirect("/Admin/BannersAdmin/Index");
            }
            return Redirect(Common.Links.NOT_404);
        }

        // Active
        public JsonResult ActiveBanner(int? id)
        {
            var dao = new BannersDAO();
            if (dao.Active(id))
            {
                // Giá trị Angular
                List<Banners> banners = db.Banners.Where(n => n.banner_bin == false).ToList();
                // Tẹn biến
                List<jBanners> list = banners.Select(n => new jBanners
                {
                    id = n.banner_id,
                    name = n.banner_name,
                    svg = n.banner_svg,
                    datecreate = n.banner_datecreate.Value.ToShortDateString(),
                    update = n.banner_update.Value.ToShortDateString(),
                    active = n.banner_active,
                    bin = n.banner_bin,
                    option = n.banner_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null);
            }
        }

        // Option
        public JsonResult OptionBanner(int? id)
        {
            var dao = new BannersDAO();
            if (dao.Option(id))
            {
                // Giá trị Angular
                List<Banners> banners = db.Banners.Where(n => n.banner_bin == false).ToList();
                // Tẹn biến
                List<jBanners> list = banners.Select(n => new jBanners
                {
                    id = n.banner_id,
                    name = n.banner_name,
                    svg = n.banner_svg,
                    datecreate = n.banner_datecreate.Value.ToShortDateString(),
                    update = n.banner_update.Value.ToShortDateString(),
                    active = n.banner_active,
                    bin = n.banner_bin,
                    option = n.banner_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null);
            }
        }

        public ActionResult IndexBin()
        {
            return View(db.Banners.Where(n => n.banner_bin == true).ToList());
        }

        // Delete
        public JsonResult DeleteBanner(int? id)
        {
            var dao = new BannersDAO();
            if (dao.Delete(id))
            {
                // Giá trị Angular
                List<Banners> banners = db.Banners.Where(n => n.banner_bin == true).OrderByDescending(n => n.banner_datecreate).ToList();
                // Tẹn biến
                List<jBanners> list = banners.Select(n => new jBanners
                {
                    id = n.banner_id,
                    name = n.banner_name,
                    svg = n.banner_svg,
                    datecreate = n.banner_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.banner_update.Value.ToString("yyyy-MM-dd"),
                    active = n.banner_active,
                    bin = n.banner_bin,
                    option = n.banner_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        // Restore
        public JsonResult RestoreBanner(int? id)
        {
            var dao = new BannersDAO();
            if (dao.Restore(id))
            {
                // Giá trị Angular
                List<Banners> banners = db.Banners.Where(n => n.banner_bin == true).OrderByDescending(n => n.banner_datecreate).ToList();
                // Tẹn biến
                List<jBanners> list = banners.Select(n => new jBanners
                {
                    id = n.banner_id,
                    name = n.banner_name,
                    svg = n.banner_svg,
                    datecreate = n.banner_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.banner_update.Value.ToString("yyyy-MM-dd"),
                    active = n.banner_active,
                    bin = n.banner_bin,
                    option = n.banner_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }
    }
}