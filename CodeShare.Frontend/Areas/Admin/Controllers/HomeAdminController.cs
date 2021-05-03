using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        DataShareCodeEntities db = new DataShareCodeEntities();
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if(cookie != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login","UsersAdmin");
            }
        }
    }
}