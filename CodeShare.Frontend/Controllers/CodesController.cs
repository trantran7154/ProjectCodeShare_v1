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
        public ActionResult Index(string key)
        {

            if (key == "1")
            {
                ViewBag.key = "list.coin > 200";
            }
            else if (key == "2")
            {
                ViewBag.key = "list.coin > 0 && list.coin < 201";
            }
            else if (key == "3")
            {
                ViewBag.key = "list.coin == 0";
            }
            else
            {
                ViewBag.key = key;
            }
            return View();
        }
        public ActionResult MyCodes()
        {
            return View();
        }
        public PartialViewResult NewSourceCodes()
        {
            return PartialView();
        }

        public ActionResult Details(int id)
        {
            var code = db.Codes.Find(id);
            code.code_view = code.code_view + 1;
            db.SaveChanges();

            return View(code);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Code codes, string[] language, string[] tags, HttpPostedFileBase img)
        {
            var coo = new FunctionsController();
            var id = coo.Cookie();
            var idus = coo.CookieID();
            if(id == null)
            {
                return Redirect("/User/Login");
            }
            else
            {
                var tag = "";
                foreach (var item in tags)
                {
                    tag += item + ";";
                }
                codes.code_tag = tag;
                codes.user_id = idus.user_id;
                codes.code_img = images.UpLoadImages(img, null, "Codes");
                codesDAO.Create(codes, language);

                return RedirectToAction("MyCodes");
            }
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
                codes.code_img = images.UpLoadImages(img, codes.code_img, "Codes");
                codesDAO.Edit(codes, language);
            }
            return View();
        }
        public ActionResult PayCode(int ? coder, int? id)
        {
            var coo = new FunctionsController();
            var idus = coo.CookieID();


            Code code = db.Codes.Find(id);

            int pt5 = 5;
            int pt7 = 7;
            int pt10 = 10;
            float sum5 = (float)(code.code_coin * (1 - (float)pt5 / 100));
            float sum7 = (float)(code.code_coin * (1 - (float)pt7 / 100));
            float sum10 = (float)(code.code_coin * (1 - (float)pt10 / 100));



            User idmain = db.Users.Find(idus.user_id);
            idmain.user_coin = idmain.user_coin - code.code_coin;

            User idcoder = db.Users.Find(coder);
            if(code.code_coin < 50)
            {
                idcoder.user_coin = idcoder.user_coin + code.code_coin;
            }
            else if(code.code_coin < 1000000)
            {
                idcoder.user_coin = (int?)(idcoder.user_coin + sum5);
            }
            else if(code.code_coin < 5000000)
            {
                idcoder.user_coin = (int?)(idcoder.user_coin + sum7);
            }
            else
            {
                idcoder.user_coin = (int?)(idcoder.user_coin + sum10);
            }
            db.SaveChanges();

            Order oder = new Order()
            {
                code_id = id,
                id_coder = coder,
                oder_datecreate = DateTime.Now,
                user_id = idus.user_id
            };
            db.Orders.Add(oder);
            db.SaveChanges();

            Order oder1 = db.Orders.Where(n => n.user_id == idus.user_id && n.code_id == id).First();



            return RedirectToAction("DetailsCodeSell", new { id = oder1.oder_id });
        }
        //Danh sách code đã mua
        public ActionResult IndexCodeOder()
        {
            return View();
        }
        //Danh sách code mã bán
        public ActionResult IndexCodeSell()
        {
            return View();
        }
        //Xem chi tiet hoa don mua duoc
        public ActionResult DetailsCodeSell(int ? id)
        {
            return View(db.Orders.Find(id));
        }
    }
}