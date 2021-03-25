using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;
using CodeShare.Frontend.Functions;
using CodeShare.Frontend.Models;

namespace CodeShare.Frontend.Controllers
{
    public class JsonController : Controller
    {
        DataShareCodeEntities db = new DataShareCodeEntities();
        // GET: Json
        public ActionResult Index()
        {
            return View();
        }
        //Tra ve nguoi dung
        public JsonResult Users()
        {
            var co = new FunctionsController();
            var id = co.CookieID();
            List<User> users = db.Users.Where(n => n.user_id == id.user_id).ToList();
            List<jUsers> list = users.Select(n => new jUsers
            {
                

            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //Danh sách code
        public JsonResult Codes()
        {
            var co = new FunctionsController();
            var id = co.CookieID();
            List<Code> codes = db.Codes.Where(n => n.user_id == id.user_id).ToList();
            List<jCodes> list = codes.Select(n => new jCodes
            {
                

            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}