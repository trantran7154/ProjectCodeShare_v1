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
    public class CategorysAdminController : Controller
    {

        private CodeShareDataEntities db = new CodeShareDataEntities();

        // GET: Admin/CategorysAdmin
        public ActionResult Index()
        { 
            return View(db.Categorys.Where(n => n.category_bin == false).ToList());
        }

        // Create
        public ActionResult CreateCate(Categorys categorys)
        {
            categorys.category_option = true;
            categorys.category_bin = false;

            var dao = new CategorysDAO();
            if (dao.Create(categorys))
            {
                return Redirect("/Admin/CategorysAdmin/Index");
            }
            else
            {
                return Redirect(Common.Links.NOT_404);
            }
        }

        // Xóa vào thùng rác
        public JsonResult BinCate(int? id)
        {
            var dao = new CategorysDAO();
            if (dao.Bin(id))
            {
                // Giá trị Angular
                List<Categorys> categorys = db.Categorys.Where(n => n.category_bin == false).ToList();
                // Tên biến
                List<jCategorys> list = categorys.Select(n => new jCategorys
                {
                    id = n.category_id,
                    name = n.category_name,
                    datecreate = n.category_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.category_update.Value.ToString("yyyy-MM-dd"),
                    bin = n.category_bin,
                    active = n.category_active,
                    option = n.category_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null);
            }
        }

        // Edit
        public ActionResult EditCate(Categorys categorys)
        {

            Categorys cate = db.Categorys.Find(categorys.category_id);

            categorys.category_option = cate.category_option;
            categorys.category_active = cate.category_active;
            categorys.category_datecreate = cate.category_datecreate;
            categorys.category_bin = cate.category_bin;

            var dao = new CategorysDAO();
            if (dao.Edit(categorys))
            {
                return Redirect("/Admin/CategorysAdmin/Index");
            }
            else
            {
                return Redirect(Common.Links.NOT_404);
            }
        }

        // Active
        public JsonResult ActiveCate(int? id)
        {
            var dao = new CategorysDAO();
            if (dao.Active(id))
            {
                // Giá trị Angular
                List<Categorys> categorys = db.Categorys.Where(n => n.category_bin == false).ToList();
                // Tên biến
                List<jCategorys> list = categorys.Select(n => new jCategorys
                {
                    id = n.category_id,
                    name = n.category_name,
                    datecreate = n.category_datecreate.Value.ToShortDateString().ToString(),
                    update = n.category_update.Value.ToShortDateString().ToString(),
                    bin = n.category_bin,
                    active = n.category_active,
                    option = n.category_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null);
            }
        }

        // Option
        public ActionResult OptionCate(int? id)
        {
            var dao = new CategorysDAO();
            if (dao.Option(id))
            {
                // Giá trị Angular
                List<Categorys> categorys = db.Categorys.Where(n => n.category_bin == false).ToList();
                // Tên biến
                List<jCategorys> list = categorys.Select(n => new jCategorys
                {
                    id = n.category_id,
                    name = n.category_name,
                    datecreate = n.category_datecreate.Value.ToShortDateString().ToString(),
                    update = n.category_update.Value.ToShortDateString().ToString(),
                    bin = n.category_bin,
                    active = n.category_active,
                    option = n.category_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null);
            }
        }

        // Dữ liệu đã xóa
        public ActionResult IndexBin()
        {
            return View(db.Categorys.Where(n => n.category_bin == true).ToList());
        }

        // Khôi phục
        public JsonResult RestoreCate(int? id)
        {
            var dao = new CategorysDAO();
            if (dao.Restore(id))
            {
                // Giá trị Angular
                List<Categorys> categorys = db.Categorys.Where(n => n.category_bin == true).ToList();
                // Tên biến
                List<jCategorys> list = categorys.Select(n => new jCategorys
                {
                    id = n.category_id,
                    name = n.category_name,
                    datecreate = n.category_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.category_update.Value.ToString("yyyy-MM-dd"),
                    bin = n.category_bin,
                    active = n.category_active,
                    option = n.category_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null);
            }
        }

        // Xóa vào vĩnh viễn
        public JsonResult DeleteCate(int? id)
        {
            var dao = new CategorysDAO();
            if (dao.Delete(id))
            {
                // Giá trị Angular
                List<Categorys> categorys = db.Categorys.Where(n => n.category_bin == true).ToList();
                // Tên biến
                List<jCategorys> list = categorys.Select(n => new jCategorys
                {
                    id = n.category_id,
                    name = n.category_name,
                    datecreate = n.category_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.category_update.Value.ToString("yyyy-MM-dd"),
                    bin = n.category_bin,
                    active = n.category_active,
                    option = n.category_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null);
            }
        }
    }
}