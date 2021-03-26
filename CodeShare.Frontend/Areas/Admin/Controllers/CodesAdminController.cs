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
        CodeShareDataEntities db = new CodeShareDataEntities();
        public ActionResult Index()
        {
            return View(db.Codes.Where(n => n.code_bin == false).ToList());
        }

        // Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateCode(Codes codes,HttpPostedFileBase IMG, string[] tags)
        {
            var code = Guid.NewGuid().ToString();
            var addimg = new ImagesController();

            codes.code_bin = false;

            codes.code_active = true;
            codes.code_option = true;

            codes.code_view = 1;

            if (IMG == null)
            {
                codes.code_img = "notimg.png";
            }
            else
            {
                addimg.AddImages(IMG,Common.Links.IMG_CODES,code);
                codes.code_img = code + IMG.FileName;
            }

            var dao = new CodesDAO();
            if(dao.Create(codes, tags))
            {
                return Redirect("/Admin/CodesAdmin/Index");
            }
            else
            {
                return Redirect(Common.Links.NOT_404);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditCode(Codes codes, HttpPostedFileBase IMG, string[] tags)
        {
            var code = Guid.NewGuid().ToString();
            var addimg = new ImagesController();

            codes.code_bin = false;

            codes.code_active = true;
            codes.code_option = true;

            codes.code_view = 1;

            Codes codes1 = db.Codes.Find(codes.code_id);

            if (IMG == null)
            {
                codes.code_img = codes1.code_img;
            }
            else
            {

                addimg.AddImages(IMG, Common.Links.IMG_CODES, code);
                codes.code_img = code + IMG.FileName;
            }

            var dao = new CodesDAO();
            if (dao.Edit(codes, tags))
            {
                return Redirect("/Admin/CodesAdmin/Index");
            }
            else
            {
                return Redirect(Common.Links.NOT_404);
            }
        }

        // Active
        public JsonResult ActiveCode(int? id)
        {
            var dao = new CodesDAO();
            if (dao.Active(id))
            {

                // Giá trị Angular
                List<Codes> codes = db.Codes.Where(n => n.code_bin == false).OrderByDescending(n => n.code_datecreate).ToList();
                // Tên biến
                List<jCodes> list = codes.Select(n => new jCodes
                {
                    id = n.code_id,
                    name = n.code_name,
                    img = n.code_img,
                    description = n.code_description,
                    capacity = n.code_capacity,
                    link = n.code_link,
                    coin = n.code_coin,
                    view = n.code_view,
                    datecreate = n.code_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.code_update.Value.ToString("yyyy-MM-dd"),
                    active = n.code_active,
                    bin = n.code_bin,
                    option = n.code_option,
                    introduce = n.code_introduce,
                    down = n.code_down,
                    browser_demo = n.code_browser_demo,
                    demo = n.code_demo,
                    point_refer = n.code_point_refer,
                    browser_quality = n.code_browser_quality,
                    point_quality = n.code_point_quality,
                    browser_downoad = n.code_browser_downoad,
                    browser_error = n.code_browser_error,
                    banner_id = n.banner_id,
                    form_id = n.form_id,
                    user_id = n.user_id,
                    user_name = n.code_name
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        // Option
        public JsonResult OptionCode(int? id)
        {
            var dao = new CodesDAO();
            if (dao.Option(id))
            {

                // Giá trị Angular
                List<Codes> codes = db.Codes.Where(n => n.code_bin == false).OrderByDescending(n => n.code_datecreate).ToList();
                // Tên biến
                List<jCodes> list = codes.Select(n => new jCodes
                {
                    id = n.code_id,
                    name = n.code_name,
                    img = n.code_img,
                    description = n.code_description,
                    capacity = n.code_capacity,
                    link = n.code_link,
                    coin = n.code_coin,
                    view = n.code_view,
                    datecreate = n.code_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.code_update.Value.ToString("yyyy-MM-dd"),
                    active = n.code_active,
                    bin = n.code_bin,
                    option = n.code_option,
                    introduce = n.code_introduce,
                    down = n.code_down,
                    browser_demo = n.code_browser_demo,
                    demo = n.code_demo,
                    point_refer = n.code_point_refer,
                    browser_quality = n.code_browser_quality,
                    point_quality = n.code_point_quality,
                    browser_downoad = n.code_browser_downoad,
                    browser_error = n.code_browser_error,
                    banner_id = n.banner_id,
                    form_id = n.form_id,
                    user_id = n.user_id,
                    user_name = n.code_name
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        // Bin
        public JsonResult BinCode(int? id)
        {
            var dao = new CodesDAO();
            if (dao.Bin(id))
            {

                // Giá trị Angular
                List<Codes> codes = db.Codes.Where(n => n.code_bin == false).OrderByDescending(n => n.code_datecreate).ToList();
                // Tên biến
                List<jCodes> list = codes.Select(n => new jCodes
                {
                    id = n.code_id,
                    name = n.code_name,
                    img = n.code_img,
                    description = n.code_description,
                    capacity = n.code_capacity,
                    link = n.code_link,
                    coin = n.code_coin,
                    view = n.code_view,
                    datecreate = n.code_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.code_update.Value.ToString("yyyy-MM-dd"),
                    active = n.code_active,
                    bin = n.code_bin,
                    option = n.code_option,
                    introduce = n.code_introduce,
                    down = n.code_down,
                    browser_demo = n.code_browser_demo,
                    demo = n.code_demo,
                    point_refer = n.code_point_refer,
                    browser_quality = n.code_browser_quality,
                    point_quality = n.code_point_quality,
                    browser_downoad = n.code_browser_downoad,
                    browser_error = n.code_browser_error,
                    banner_id = n.banner_id,
                    form_id = n.form_id,
                    user_id = n.user_id,
                    user_name = n.code_name
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        public ActionResult IndexBin()
        {
            return View(db.Codes.Where(n => n.code_bin == true).ToList());
        }

        // Restore
        public JsonResult RestoreCode(int? id)
        {
            var dao = new CodesDAO();
            if (dao.Restore(id))
            {

                // Giá trị Angular
                List<Codes> codes = db.Codes.Where(n => n.code_bin == true).OrderByDescending(n => n.code_datecreate).ToList();
                // Tên biến
                List<jCodes> list = codes.Select(n => new jCodes
                {
                    id = n.code_id,
                    name = n.code_name,
                    img = n.code_img,
                    description = n.code_description,
                    capacity = n.code_capacity,
                    link = n.code_link,
                    coin = n.code_coin,
                    view = n.code_view,
                    datecreate = n.code_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.code_update.Value.ToString("yyyy-MM-dd"),
                    active = n.code_active,
                    bin = n.code_bin,
                    option = n.code_option,
                    introduce = n.code_introduce,
                    down = n.code_down,
                    browser_demo = n.code_browser_demo,
                    demo = n.code_demo,
                    point_refer = n.code_point_refer,
                    browser_quality = n.code_browser_quality,
                    point_quality = n.code_point_quality,
                    browser_downoad = n.code_browser_downoad,
                    browser_error = n.code_browser_error,
                    banner_id = n.banner_id,
                    form_id = n.form_id,
                    user_id = n.user_id,
                    user_name = n.code_name
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        // Delete
        public JsonResult DeleteCode(int? id)
        {
            var dao = new CodesDAO();
            if (dao.Delete(id))
            {

                // Giá trị Angular
                List<Codes> codes = db.Codes.Where(n => n.code_bin == true).OrderByDescending(n => n.code_datecreate).ToList();
                // Tên biến
                List<jCodes> list = codes.Select(n => new jCodes
                {
                    id = n.code_id,
                    name = n.code_name,
                    img = n.code_img,
                    description = n.code_description,
                    capacity = n.code_capacity,
                    link = n.code_link,
                    coin = n.code_coin,
                    view = n.code_view,
                    datecreate = n.code_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.code_update.Value.ToString("yyyy-MM-dd"),
                    active = n.code_active,
                    bin = n.code_bin,
                    option = n.code_option,
                    introduce = n.code_introduce,
                    down = n.code_down,
                    browser_demo = n.code_browser_demo,
                    demo = n.code_demo,
                    point_refer = n.code_point_refer,
                    browser_quality = n.code_browser_quality,
                    point_quality = n.code_point_quality,
                    browser_downoad = n.code_browser_downoad,
                    browser_error = n.code_browser_error,
                    banner_id = n.banner_id,
                    form_id = n.form_id,
                    user_id = n.user_id,
                    user_name = n.code_name
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }
    }
}