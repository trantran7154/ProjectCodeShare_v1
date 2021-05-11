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
                ViewBag.key = "list.coin > 100";
                ViewBag.name = "CODE CHẤT LƯỢNG";
            }
            else if (key == "2")
            {
                ViewBag.key = "list.coin > 0 && list.coin < 100";
                ViewBag.name = "CODE THAM KHẢO";
            }
            else if (key == "3")
            {
                ViewBag.key = "list.coin == 0";
                ViewBag.name = "CODE MIỄN PHÍ";
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
            code.Category.category_view = code.Category.category_view + 1;
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
                return Redirect("/Users/Login");
            }
            else
            {
                //var tag = "";
                //foreach (var item in tags)
                //{
                //    tag += item + ";";
                //}
                //codes.code_tag = tag;
                codes.user_id = idus.user_id;
                codes.code_img = images.UpLoadImages(img, null, "Codes");


                History history = new History()
                {
                    user_id = idus.user_id,
                    his_datecreate = DateTime.Now,
                    his_content = idus.user_name + " đã thêm code " + codes.code_title + " thành công!"
                };
                db.Historys.Add(history);

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

            int pt95 = 95;
            int pt93 = 93;
            int pt90 = 90;

            float sum5 = (float)(code.code_coin * (1 - (float)pt5 / 100));
            float sum7 = (float)(code.code_coin * (1 - (float)pt7 / 100));
            float sum10 = (float)(code.code_coin * (1 - (float)pt10 / 100));

            float sum95 = (float)(code.code_coin * (1 - (float)pt95 / 100));
            float sum93 = (float)(code.code_coin * (1 - (float)pt93 / 100));
            float sum90 = (float)(code.code_coin * (1 - (float)pt90 / 100));

            User idmain = db.Users.Find(idus.user_id);
            idmain.user_coin = idmain.user_coin - code.code_coin;

            User idcoder = db.Users.Find(coder);
            if(code.code_coin <= 100)
            {
                idcoder.user_coin = idcoder.user_coin + code.code_coin;

                Order oder = new Order()
                {
                    code_id = id,
                    id_coder = coder,
                    oder_datecreate = DateTime.Now,
                    user_id = idus.user_id,
                    coin = code.code_coin,
                    cate_orders = 1
                };
                db.Orders.Add(oder);
            }
            else if(code.code_coin <= 1000)
            {
                idcoder.user_coin = (int?)(idcoder.user_coin + sum5);
                Order odercate = new Order()
                {
                    code_id = id,
                    id_coder = coder,
                    oder_datecreate = DateTime.Now,
                    user_id = idus.user_id,
                    coin = (int?)sum95,
                    cate_orders = 2
                };
                db.Orders.Add(odercate);

                Order oder = new Order()
                {
                    code_id = id,
                    id_coder = coder,
                    oder_datecreate = DateTime.Now,
                    user_id = idus.user_id,
                    coin = (int?)sum5,
                    cate_orders = 1
                };
                db.Orders.Add(oder);
            }
            else if(code.code_coin <= 5000)
            {
                idcoder.user_coin = (int?)(idcoder.user_coin + sum7);
                Order odercate = new Order()
                {
                    code_id = id,
                    id_coder = coder,
                    oder_datecreate = DateTime.Now,
                    user_id = idus.user_id,
                    coin = (int?)sum93,
                    cate_orders = 2
                };
                db.Orders.Add(odercate);

                Order oder = new Order()
                {
                    code_id = id,
                    id_coder = coder,
                    oder_datecreate = DateTime.Now,
                    user_id = idus.user_id,
                    coin = (int?)sum7,
                    cate_orders = 1
                };
                db.Orders.Add(oder);
            }
            else
            {
                idcoder.user_coin = (int?)(idcoder.user_coin + sum10);
                Order odercate = new Order()
                {
                    code_id = id,
                    id_coder = coder,
                    oder_datecreate = DateTime.Now,
                    user_id = idus.user_id,
                    coin = (int?)sum90,
                    cate_orders = 2
                };
                db.Orders.Add(odercate);

                Order oder = new Order()
                {
                    code_id = id,
                    id_coder = coder,
                    oder_datecreate = DateTime.Now,
                    user_id = idus.user_id,
                    coin = (int?)sum10,
                    cate_orders = 1
                };
                db.Orders.Add(oder);
            }
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
        //Bình luận
        public JsonResult Comment(string content, int ? id)
        {
            var coo = new FunctionsController();
            var idus = coo.CookieID();

            Comment comment = new Comment
            {
                code_id = id,
                comment_content = content,
                comment_datecreate = DateTime.Now,
                user_id = idus.user_id
            };
            db.Comments.Add(comment);
            db.SaveChanges();


            var list = from item in db.Comments
                       where item.code_id == id
                       orderby item.comment_dateupdate descending
                       select new
                       {
                           id = item.comment_id,
                           idcode = item.code_id,
                           idus = item.user_id,
                           date = item.comment_datecreate.ToString(),
                           update = item.comment_dateupdate,
                           content = item.comment_content,
                           nameid = item.User.user_name,
                           imgid = item.User.user_img

                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //Yêu thích
        public JsonResult FavouriteCode(int? idcode)
        {
            var cookie = new FunctionsController();
            var idus = cookie.CookieID();

            Group group = new Group()
            {
                code_id = idcode,
                user_id = idus.user_id,
                group_datecreate = DateTime.Now,
                group_item = Common.Common.ITEM_CODE_USER
            };
            db.Groups.Add(group);
            db.SaveChanges();

            var fa = db.Groups.Where(n => n.group_item == Common.Common.ITEM_CODE_USER && n.user_id == idus.user_id && n.code_id == idcode).OrderByDescending(n => n.group_datecreate).Select(n => new
            {
                id = n.group_id

            }).ToList();

            return Json(fa, JsonRequestBehavior.AllowGet);
        }
        //Danh sách yêu thích theo người dùng và code
        public JsonResult JsonFavourite(int ? idcode)
        {
            var cookie = new FunctionsController();
            var idus = cookie.CookieID();
            var fa = db.Groups.Where(n => n.group_item == Common.Common.ITEM_CODE_USER && n.user_id == idus.user_id && n.code_id == idcode).OrderByDescending(n => n.group_datecreate).Select(n => new
            {
                id = n.group_id

            }).ToList();
            return Json(fa,JsonRequestBehavior.AllowGet);
        }
        //Huy yeu thich
        public JsonResult CancelFavourite(int? id)
        {
            var cookie = new FunctionsController();
            var idus = cookie.CookieID();

            Group group = db.Groups.Find(id);
            var idcode = group.code_id;
            db.Groups.Remove(group);
            db.SaveChanges();

            var fa = db.Groups.Where(n => n.group_item == Common.Common.ITEM_CODE_USER && n.user_id == idus.user_id && n.code_id == idcode).OrderByDescending(n => n.group_datecreate).Select(n => new
            {
                id = n.group_id

            }).ToList();
            return Json(fa, JsonRequestBehavior.AllowGet);
        }
        //Quản lý code
        public ActionResult MyFavouriteCode()
        {
            return View();
        }
        //Danh sách chi tiết yêu thích code
        public JsonResult JsonIndexFavourite()
        {
            var cookie = new FunctionsController();
            var idus = cookie.CookieID();
            var fa = db.Groups.Where(n => n.group_item == Common.Common.ITEM_CODE_USER && n.user_id == idus.user_id).OrderByDescending(n => n.group_datecreate).Select(n => new
            {
                id = n.group_id,
                idcode = n.Code.code_id,
                title = n.Code.code_title,
                view = n.Code.code_view,
                coin = n.Code.code_coin,
                price = n.Code.code_coin * 1000,
                img = n.Code.code_img

            }).ToList();
            return Json(fa, JsonRequestBehavior.AllowGet);
        }
        //Tìm kiếm code
        public ActionResult SearchCode(string k, string c, string l)
        {
            ViewBag.Key = k;
            ViewBag.Cate = c;
            ViewBag.Lang = l;
            return View();
        }
        [HttpPost]
        public ActionResult PostSearchCode(string key, string cate, string lang)
        {
            return RedirectToAction("SearchCode", new { k = key, c = cate, l = lang });
        }
    }
}