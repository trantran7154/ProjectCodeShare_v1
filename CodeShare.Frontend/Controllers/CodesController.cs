using CodeShare.Frontend.Functions;
using CodeShare.Model.DAO;
using CodeShare.Model.EF;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeShare.Frontend.Controllers
{
    public class CodesController : Controller
    {
        DataShareCodeEntities db = new DataShareCodeEntities();
        CodesDao codesDAO = new CodesDao();
        ImagesController images = new ImagesController();
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
        public ActionResult Create(Code codes, string[] language, string[] code_tag, HttpPostedFileBase img)
        {
            var coo = new FunctionsController();
            var id = coo.CookieID();

            if (ModelState.IsValid)
            {
                var tag = "";
                foreach(var item in code_tag)
                {
                    tag += item + ";";
                }
                codes.code_tag = tag;
                codes.code_img = images.AddImages(img, "Codes", Guid.NewGuid().ToString());
                codesDAO.Create(codes, language);
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
            if (id == null)
            {
                return HttpNotFound();
            }
            var code = db.Codes.Find(id);
            if (code == null)
            {
                return HttpNotFound();
            }
            return View(code);
        }
        public ActionResult Edit(Code codes, string[] language, string[] code_tag, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                var tag = "";
                foreach (var item in code_tag)
                {
                    tag += item + ";";
                }
                codes.code_tag = tag;
                codes.code_img = images.AddImages(img, "Codes", Guid.NewGuid().ToString());
                codesDAO.Edit(codes, language);
            }
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}