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
    public class PakagesAdminController : Controller
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // GET: Admin/PakagesAdmin
        public ActionResult Index()
        {
            return View(db.Pakages.ToList());
        }

        // GET: Admin/PakagesAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pakage pakage = db.Pakages.Find(id);
            if (pakage == null)
            {
                return HttpNotFound();
            }
            return View(pakage);
        }

        // GET: Admin/PakagesAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PakagesAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pakege_id,pakage_coin,pakage_money,pakage_active")] Pakage pakage)
        {
            pakage.pakage_active = 1;

            db.Pakages.Add(pakage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/PakagesAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pakage pakage = db.Pakages.Find(id);
            if (pakage == null)
            {
                return HttpNotFound();
            }
            return View(pakage);
        }

        // POST: Admin/PakagesAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pakege_id,pakage_coin,pakage_money,pakage_active")] Pakage pakage)
        {
            var coin = pakage.pakage_coin * 1000;
            if (ModelState.IsValid)
            {
                db.Entry(pakage).State = EntityState.Modified;
                pakage.pakage_money = coin.Value.ToString("#,##0") + " VNĐ";
                pakage.pakage_active = 1;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pakage);
        }

        // GET: Admin/PakagesAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pakage pakage = db.Pakages.Find(id);
            if (pakage == null)
            {
                return HttpNotFound();
            }
            return View(pakage);
        }

        // POST: Admin/PakagesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pakage pakage = db.Pakages.Find(id);
            db.Pakages.Remove(pakage);
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

        // Check trạng thái hoạt động của gói nạp
        public JsonResult ActivePackages(int? id)
        {
            Pakage pakage = db.Pakages.Find(id);
            if (pakage.pakage_active == 1)
            {
                pakage.pakage_active = 2;
            }
            else
            {
                pakage.pakage_active = 1;
            }
            db.SaveChanges();
            var list = from item in db.Pakages
                       where item.pakage_active == 1
                       select new
                       {
                           id = (int)item.pakege_id,
                           coin = (int)item.pakage_coin,
                           money = item.pakage_money.ToString(),
                           active = (int)item.pakage_active
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UnActive()
        {
            return View();
        }

        public JsonResult ShowUnActive(int? id)
        {
            var list = from item in db.Pakages
                       where item.pakage_active == 2
                       select new
                       {
                           id = (int)item.pakege_id,
                           coin = (int)item.pakage_coin,
                           money = item.pakage_money.ToString(),
                           active = (int)item.pakage_active
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Khôi phục
        public JsonResult Restore(int? id)
        {
            Pakage pakage = db.Pakages.Find(id);
            if (pakage.pakage_active == 1)
            {
                pakage.pakage_active = 2;
            }
            else
            {
                pakage.pakage_active = 1;
            }
            db.SaveChanges();
            var list = from item in db.Pakages
                       where item.pakage_active == 2
                       select new
                       {
                           id = (int)item.pakege_id,
                           coin = (int)item.pakage_coin,
                           money = item.pakage_money.ToString(),
                           active = (int)item.pakage_active
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
