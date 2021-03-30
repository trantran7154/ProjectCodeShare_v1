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
    public class CodesAdminController : Controller
    {
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // GET: Admin/Codes
        public ActionResult Index()
        {
            var codes = db.Codes.Include(c => c.Category).Include(c => c.User);
            return View(codes.ToList());
        }

        // GET: Admin/Codes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Code code = db.Codes.Find(id);
            if (code == null)
            {
                return HttpNotFound();
            }
            return View(code);
        }

        // GET: Admin/Codes/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.Categorys, "category_id", "category_name");
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email");
            return View();
        }

        // POST: Admin/Codes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "code_id,code_title,code_coin,code_code,code_des,code_info,code_setting,code_view,code_viewdown,code_linkdemo,code_linkdown,code_datecreate,code_dateupdate,code_active,code_option,code_del,code_tag,code_disk,code_pass,category_id,user_id,code_img")] Code code)
        {
            if (ModelState.IsValid)
            {
                db.Codes.Add(code);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.Categorys, "category_id", "category_name", code.category_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", code.user_id);
            return View(code);
        }

        // GET: Admin/Codes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Code code = db.Codes.Find(id);
            if (code == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.Categorys, "category_id", "category_name", code.category_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", code.user_id);
            return View(code);
        }

        // POST: Admin/Codes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "code_id,code_title,code_coin,code_code,code_des,code_info,code_setting,code_view,code_viewdown,code_linkdemo,code_linkdown,code_datecreate,code_dateupdate,code_active,code_option,code_del,code_tag,code_disk,code_pass,category_id,user_id,code_img")] Code code)
        {
            if (ModelState.IsValid)
            {
                db.Entry(code).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.Categorys, "category_id", "category_name", code.category_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_email", code.user_id);
            return View(code);
        }

        // GET: Admin/Codes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Code code = db.Codes.Find(id);
            if (code == null)
            {
                return HttpNotFound();
            }
            return View(code);
        }

        // POST: Admin/Codes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Code code = db.Codes.Find(id);
            db.Codes.Remove(code);
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
    }
}
