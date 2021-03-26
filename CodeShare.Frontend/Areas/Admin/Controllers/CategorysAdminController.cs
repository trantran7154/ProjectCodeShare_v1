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

        private DataShareCodeEntities db = new DataShareCodeEntities();

        // GET: Admin/CategorysAdmin
        public ActionResult Index()
        { 
            return View(db.Categorys.ToList());
        }

        // Create
        public ActionResult CreateCate(Category categorys)
        {
            categorys.category_active = true;

            var dao = new CategorysDao();
            if (dao.Create(categorys))
            {
                return Redirect("/Admin/CategorysAdmin/Index");
            }
            else
            {
                return Redirect(Common.Links.NOT_404);
            }
        }

        // Edit
        public ActionResult EditCate(Category categorys)
        {

            Category cate = db.Categorys.Find(categorys.category_id);

            categorys.category_active = cate.category_active;

            var dao = new CategorysDao();
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
            var dao = new CategorysDao();
            if (dao.Active(id))
            {
                // Giá trị Angular
                List<Category> categorys = db.Categorys.ToList();
                // Tên biến
                List<jCategorys> list = categorys.Select(n => new jCategorys
                {
                    active = n.category_active,
                    id = n.category_id,
                    item = (int)n.category_item,
                    name = n.category_name.ToString()
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
            var dao = new CategorysDao();
            if (dao.Option(id))
            {
                // Giá trị Angular
                List<Category> categorys = db.Categorys.ToList();
                // Tên biến
                List<jCategorys> list = categorys.Select(n => new jCategorys
                {
                    active = n.category_active,
                    id = n.category_id,
                    item = (int)n.category_item,
                    name = n.category_name.ToString()
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