using CodeShare.Frontend.Functions;
using CodeShare.Model.DAO;
using CodeShare.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeShare.Frontend.Controllers
{
    public class RepController : Controller
    {
        RepDao repDao = new RepDao();
        FunctionsController functions = new FunctionsController();
        // GET: Rep
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Addrep(Rep rep)
        {
            if (functions.CookieID() == null)
            {
                return Redirect("/Users/Login");
            }
            else if (ModelState.IsValid)
            {
                repDao.Create(rep);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Editrep(Rep rep)
        {
            if (functions.CookieID() == null)
            {
                return Redirect("/Users/Login");
            }
            else if (ModelState.IsValid)
            {
                repDao.Edit(rep);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Deleterep(int? id)
        {
            if (functions.CookieID() == null)
            {
                return Redirect("/Users/Login");
            }
            else if (id == null)
            {
                return new HttpNotFoundResult();
            }
            else if (ModelState.IsValid)
            {
                repDao.Delete(id);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}