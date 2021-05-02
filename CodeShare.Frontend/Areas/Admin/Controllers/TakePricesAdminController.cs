using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class TakePricesAdminController : Controller
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // GET: Admin/TakePricesAdmin
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["user_id"];
            if (cookie != null)
            {
                var takePrices = db.TakePrices.Include(t => t.User);
                return View(takePrices.ToList());
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // GET: Admin/TakePricesAdmin/Details/5
        public ActionResult Details(int? id)
        {
            HttpCookie cookie = Request.Cookies["user_id"];
            if (cookie != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TakePrice takePrice = db.TakePrices.Find(id);
                if (takePrice == null)
                {
                    return HttpNotFound();
                }
                return View(takePrice);
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // GET: Admin/TakePricesAdmin/Create
        public ActionResult Create()
        {
            HttpCookie cookie = Request.Cookies["user_id"];
            if (cookie != null)
            {
                ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // POST: Admin/TakePricesAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tp_id,user_id,tp_coin,tp_datecreate,tp_note,tp_active,tp_accountnumber,tp_customer,tp_momo")] TakePrice takePrice)
        {
            if (ModelState.IsValid)
            {
                db.TakePrices.Add(takePrice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", takePrice.user_id);
            return View(takePrice);
        }

        // GET: Admin/TakePricesAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            HttpCookie cookie = Request.Cookies["user_id"];
            if (cookie != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TakePrice takePrice = db.TakePrices.Find(id);
                if (takePrice == null)
                {
                    return HttpNotFound();
                }
                ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", takePrice.user_id);
                return View(takePrice);
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // POST: Admin/TakePricesAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tp_id,user_id,tp_coin,tp_datecreate,tp_note,tp_active,tp_accountnumber,tp_customer,tp_momo")] TakePrice takePrice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(takePrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", takePrice.user_id);
            return View(takePrice);
        }

        // GET: Admin/TakePricesAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TakePrice takePrice = db.TakePrices.Find(id);
            if (takePrice == null)
            {
                return HttpNotFound();
            }
            return View(takePrice);
        }

        // POST: Admin/TakePricesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TakePrice takePrice = db.TakePrices.Find(id);
            db.TakePrices.Remove(takePrice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Check trạng thái hoạt động của Rút Tiền
        public JsonResult ActivePrice(int? id)
        {
            TakePrice tk = db.TakePrices.Find(id);
            if (tk.tp_active == 1)
            {
                tk.tp_active = 2;
            }
            else
            {   
                tk.tp_active = 1;
            }

            db.SaveChanges();

            var list = from item in db.TakePrices
                       orderby item.tp_datecreate descending
                       select new
                       {
                           id = (int)item.tp_id,
                           user_id = (int)item.user_id,
                           user_name = item.User.user_name,
                           user_email = item.User.user_email,
                           coin = item.tp_coin,
                           datecreate = item.tp_datecreate.ToString(),
                           note = item.tp_note,
                           active = (int)item.tp_active,
                           accountnumber = item.tp_accountnumber,
                           customer = item.tp_customer,
                           momo = item.tp_momo
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
