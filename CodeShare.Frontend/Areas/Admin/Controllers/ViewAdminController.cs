using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;
using CodeShare.Model.DAO;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class ViewAdminController : Controller
    {
        CodeShareDataEntities db = new CodeShareDataEntities();
        // Menu
        public PartialViewResult Menu()
        {
            return PartialView();
        }
        // Danh sách danh mục
        public ActionResult Categorys()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategorys(Categorys categorys)
        {
            var dao = new CategorysDAO();
            if (dao.Create(categorys))
            {
                return Redirect("file:///C:/Users/lenovo/OneDrive/M%C3%A1y%20t%C3%ADnh/deskapp2-master/deskapp2-master/index.html");
            }
            else
            {
                return Redirect("https://localhost:44365/Home/Index#");
            }
        }
    }
}