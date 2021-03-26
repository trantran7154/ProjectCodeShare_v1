using CodeShare.Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;
using CodeShare.Model.DAO;
using CodeShare.Frontend.Functions;

namespace CodeShare.Frontend.Controllers
{
    public class CommentController : Controller
    {
        CommentDao commentDao = new CommentDao();
        FunctionsController functions = new FunctionsController();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddComment(Comment comment)
        {
            if(functions.CookieID() == null)
            {
                return Redirect("/Users/Login");
            }
            else if (ModelState.IsValid)
            {
                commentDao.Create(comment);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditComment(Comment comment)
        {
            if (functions.CookieID() == null)
            {
                return Redirect("/Users/Login");
            }
            else if (ModelState.IsValid)
            {
                commentDao.Edit(comment);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteComment(int? id)
        {
            if (functions.CookieID() == null )
            {
                return Redirect("/Users/Login");
            }
            else if(id == null)
            {
                return new HttpNotFoundResult();
            }
            else if (ModelState.IsValid)
            {
                commentDao.Delete(id);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}