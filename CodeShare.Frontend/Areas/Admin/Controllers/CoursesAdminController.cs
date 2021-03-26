using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Frontend.Functions;
using CodeShare.Model;
using CodeShare.Model.EF;
using CodeShare.Model.DAO;
using CodeShare.Common;
using CodeShare.Frontend.Models;

//namespace CodeShare.Frontend.Areas.Admin.Controllers
//{
    //public class CoursesAdminController : Controller
    //{
        // GET: Admin/CoursesAdmin
        //DataShareCodeEntities db = new DataShareCodeEntities();

        //public ActionResult Index()
        //{
        //    return View();
        //}

        // Create
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult CreateCourse(Courses courses, HttpPostedFileBase IMG)
        //{
        //    var course = Guid.NewGuid().ToString();
        //    var addimg = new ImagesController();

        //    courses.course_bin = false;

        //    courses.course_active = true;
        //    courses.course_option = true;

        //    courses.course_view = 1;

        //    if (IMG == null)
        //    {
        //        courses.course_img = "notimg.png";
        //    }
        //    else
        //    {
        //        addimg.AddImages(IMG, Common.Links.IMG_COURSES, course);
        //        courses.course_img = course + IMG.FileName;
        //    }

        //    var dao = new CoursesDAO();
        //    if (dao.Create(courses))
        //    {
        //        return Redirect("/Admin/CoursesAdmin/Index");
        //    }
        //    return Redirect(Common.Links.NOT_404);
        //}

        //// Edit
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult EditCourse(Courses courses, HttpPostedFileBase IMG)
        //{
        //    var course = Guid.NewGuid().ToString();
        //    var addimg = new ImagesController();

        //    courses.course_bin = false;

        //    courses.course_active = true;
        //    courses.course_option = true;

        //    courses.course_view = 1;

        //    Courses courses1 = db.Courses.Find(courses.course_id);

        //    if (IMG == null)
        //    {
        //        courses.course_img = courses1.course_img;
        //    }
        //    else
        //    {

        //        addimg.AddImages(IMG, Common.Links.IMG_COURSES, course);
        //        courses.course_img = course + IMG.FileName;
        //    }

        //    var dao = new CoursesDAO();
        //    if (dao.Edit(courses))
        //    {
        //        return Redirect("/Admin/CoursesAdmin/Index");
        //    }
        //    else
        //    {
        //        return Redirect(Common.Links.NOT_404);
        //    }
        //}

        //// Active
        //public JsonResult ActiveCourse(int? id)
        //{
        //    var dao = new CoursesDAO();
        //    if (dao.Active(id))
        //    {
        //        // Giá trị Angular
        //        List<Courses> courses = db.Courses.Where(n => n.course_bin == false).OrderByDescending(n => n.course_datecreate).ToList();
        //        // Tên biến
        //        List<jCourses> list = courses.Select(n => new jCourses
        //        {
        //            id = n.course_id,
        //            name = n.course_name,
        //            img = n.course_img,
        //            content = n.course_content,
        //            view = n.course_view,
        //            datecreate = n.course_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.course_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.course_active,
        //            bin = n.course_bin,
        //            option = n.course_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}

        //// Option
        //public JsonResult OptionCourse(int? id)
        //{
        //    var dao = new CoursesDAO();
        //    if (dao.Option(id))
        //    {
        //        // Giá trị Angular
        //        List<Courses> courses = db.Courses.Where(n => n.course_bin == false).OrderByDescending(n => n.course_datecreate).ToList();
        //        // Tên biến
        //        List<jCourses> list = courses.Select(n => new jCourses
        //        {
        //            id = n.course_id,
        //            name = n.course_name,
        //            img = n.course_img,
        //            content = n.course_content,
        //            view = n.course_view,
        //            datecreate = n.course_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.course_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.course_active,
        //            bin = n.course_bin,
        //            option = n.course_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}

        //// Bin
        //public JsonResult BinCourse(int? id)
        //{
        //    var dao = new CoursesDAO();
        //    if (dao.Bin(id))
        //    {
        //        // Giá trị Angular
        //        List<Courses> courses = db.Courses.Where(n => n.course_bin == false).OrderByDescending(n => n.course_datecreate).ToList();
        //        // Tên biến
        //        List<jCourses> list = courses.Select(n => new jCourses
        //        {
        //            id = n.course_id,
        //            name = n.course_name,
        //            img = n.course_img,
        //            content = n.course_content,
        //            view = n.course_view,
        //            datecreate = n.course_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.course_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.course_active,
        //            bin = n.course_bin,
        //            option = n.course_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}

        //public ActionResult IndexBin()
        //{
        //    return View();
        //}

        //// Bin
        //public JsonResult RestoreCourse(int? id)
        //{
        //    var dao = new CoursesDAO();
        //    if (dao.Restore(id))
        //    {
        //        // Giá trị Angular
        //        List<Courses> courses = db.Courses.Where(n => n.course_bin == true).OrderByDescending(n => n.course_datecreate).ToList();
        //        // Tên biến
        //        List<jCourses> list = courses.Select(n => new jCourses
        //        {
        //            id = n.course_id,
        //            name = n.course_name,
        //            img = n.course_img,
        //            content = n.course_content,
        //            view = n.course_view,
        //            datecreate = n.course_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.course_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.course_active,
        //            bin = n.course_bin,
        //            option = n.course_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}

        //// Delete
        //public JsonResult DeleteCourse(int? id)
        //{
        //    var dao = new CoursesDAO();
        //    if (dao.Delete(id))
        //    {
        //        // Giá trị Angular
        //        List<Courses> courses = db.Courses.Where(n => n.course_bin == true).OrderByDescending(n => n.course_datecreate).ToList();
        //        // Tên biến
        //        List<jCourses> list = courses.Select(n => new jCourses
        //        {
        //            id = n.course_id,
        //            name = n.course_name,
        //            img = n.course_img,
        //            content = n.course_content,
        //            view = n.course_view,
        //            datecreate = n.course_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.course_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.course_active,
        //            bin = n.course_bin,
        //            option = n.course_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}
    //}
//}