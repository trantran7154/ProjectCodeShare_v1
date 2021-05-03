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
    public class BillsAdminController : Controller
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // GET: Admin/BillsAdmin
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                var bills = db.Bills.Include(b => b.Pakage).Include(b => b.User);
                return View(bills.ToList());
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // GET: Admin/BillsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Bill bill = db.Bills.Find(id);
                if (bill == null)
                {
                    return HttpNotFound();
                }
                return View(bill);
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // GET: Admin/BillsAdmin/Create
        public ActionResult Create()
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                ViewBag.pakege_id = new SelectList(db.Pakages, "pakege_id", "pakage_money");
                ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // POST: Admin/BillsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bill_id,bill_datecreate,pakege_id,user_id,bill_active,bill_dealine")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Bills.Add(bill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pakege_id = new SelectList(db.Pakages, "pakege_id", "pakage_money", bill.pakege_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", bill.user_id);
            return View(bill);
        }

        // GET: Admin/BillsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            HttpCookie cookie = Request.Cookies["admin_id"];
            if (cookie != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Bill bill = db.Bills.Find(id);
                if (bill == null)
                {
                    return HttpNotFound();
                }
                ViewBag.pakege_id = new SelectList(db.Pakages, "pakege_id", "pakage_money", bill.pakege_id);
                ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", bill.user_id);
                return View(bill);
            }
            else
            {
                return RedirectToAction("Login", "UsersAdmin");
            }
        }

        // POST: Admin/BillsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bill_id,bill_datecreate,pakege_id,user_id,bill_active,bill_dealine")] Bill bill)
        {
            db.Entry(bill).State = EntityState.Modified;
            bill.bill_active = true;
            db.SaveChanges();

            ViewBag.pakege_id = new SelectList(db.Pakages, "pakege_id", "pakage_money", bill.pakege_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", bill.user_id);
            return RedirectToAction("Index");
        }

        // GET: Admin/BillsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Admin/BillsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill bill = db.Bills.Find(id);
            db.Bills.Remove(bill);
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

        // Check trạng thái hoạt động của Bills
        public JsonResult ActiveBill(int? id)
        {
            Bill bill = db.Bills.Find(id);
            bill.bill_active = !bill.bill_active;

            db.SaveChanges();

            var list = from item in db.Bills
                       orderby item.bill_datecreate descending
                       select new
                       {
                           id = (int)item.bill_id,
                           datecreate = item.bill_datecreate.ToString(),
                           pk_id = item.pakege_id,
                           pk_coin = (int)item.Pakage.pakage_coin,
                           user_name = item.User.user_name,
                           active = item.bill_active,
                           dealine = item.bill_dealine.ToString()
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
