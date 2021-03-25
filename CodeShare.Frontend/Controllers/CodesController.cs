using CodeShare.Model.DAO;
using CodeShare.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeShare.Frontend.Functions;

namespace CodeShare.Frontend.Controllers
{
    public class CodesController : Controller
    {
        DataShareCodeEntities db = new DataShareCodeEntities();
        CodesDao codesDAO = new CodesDao();
        // GET: Codes
        public PartialViewResult NewSourceCodes()
        {
            return PartialView();
        }

        public ActionResult Details(int id)
        {
            var code = db.Codes.Find(id);
            return View(code);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Code codes, string [] category)
        {
            var coo = new FunctionsController();
            var id = coo.CookieID();

            if (ModelState.IsValid)
            {
                
            }
            return View();
        }

        public PartialViewResult GetCategoryList(int? codeid)
        {
            ViewBag.codeid = codeid;
            var cate_list = db.Categorys.Where(t => t.category_active == true).ToList();
            return PartialView(cate_list);
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            var code = db.Codes.Find(id);
            if(code == null)
            {
                return HttpNotFound();
            }
            return View(code);
        }
        public ActionResult Edit(Code code, string[] tags)
        {
            if (ModelState.IsValid)
            {
               
            }
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}