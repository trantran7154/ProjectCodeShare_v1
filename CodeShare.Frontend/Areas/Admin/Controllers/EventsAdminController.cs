using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model;
using CodeShare.Model.EF;
using CodeShare.Model.DAO;
using CodeShare.Common;
using CodeShare.Frontend.Models;
using CodeShare.Frontend.Functions;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class EventsAdminController : Controller
    {
        // GET: Admin/EventsAdmin

        //DataShareCodeEntities db = new DataShareCodeEntities();

        //public ActionResult Index()
        //{
        //    return View(db.Events.Where(n => n.event_bin == false).ToList());
        //}

        //// Create
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult CreateEvent(Events events, HttpPostedFileBase IMG)
        //{
        //    var dao =  new EventsDAO();
        //    var event1 = Guid.NewGuid().ToString();
        //    var addimg = new ImagesController();

        //    events.event_bin = false;

        //    events.event_active = true;
        //    events.event_option = true;

        //    if (IMG == null)
        //    {
        //        events.event_img = "notimg.png";
        //    }
        //    else
        //    {
        //        addimg.AddImages(IMG, Common.Links.IMG_EVENTS, event1);
        //        events.event_img = event1 + IMG.FileName;
        //    }
        //    if (dao.Create(events))
        //    {
        //        return Redirect("/Admin/EventsAdmin/Index");
        //    }
        //    return Redirect(Common.Links.NOT_404);
        //}

        //// Edit
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult EditEvent(Events events, HttpPostedFileBase IMG)
        //{
        //    var dao = new EventsDAO();
        //    var event1 = Guid.NewGuid().ToString();
        //    var addimg = new ImagesController();

        //    events.event_bin = false;

        //    events.event_active = true;
        //    events.event_option = true;

        //    Events events1 = db.Events.Find(events.event_id);

        //    if (IMG == null)
        //    {
        //        events.event_img = events1.event_img;
        //    }
        //    else
        //    {
        //        addimg.AddImages(IMG, Common.Links.IMG_EVENTS, event1);
        //        events.event_img = event1 + IMG.FileName;
        //    }
        //    if (dao.Edit(events))
        //    {
        //        return Redirect("/Admin/EventsAdmin/Index");
        //    }
        //    return Redirect(Common.Links.NOT_404);
        //}

        //// Active
        //public JsonResult ActiveEvent(int? id)
        //{
        //    var dao = new EventsDAO();
        //    if (dao.Active(id))
        //    {
        //        // Giá trị Angular
        //        List<Events> events = db.Events.Where(n => n.event_bin == false).OrderByDescending(n => n.event_datecreate).ToList();
        //        // Tên biến
        //        List<jEvents> list = events.Select(n => new jEvents
        //        {
        //            id = n.event_id,
        //            name = n.event_name,
        //            img = n.event_img,
        //            content = n.event_content,
        //            slogan = n.event_slogan,
        //            datecreate = n.event_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.event_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.event_active,
        //            bin = n.event_bin,
        //            option = n.event_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Option
        //public JsonResult OptionEvent(int? id)
        //{
        //    var dao = new EventsDAO();
        //    if (dao.Option(id))
        //    {
        //        // Giá trị Angular
        //        List<Events> events = db.Events.Where(n => n.event_bin == false).OrderByDescending(n => n.event_datecreate).ToList();
        //        // Tên biến
        //        List<jEvents> list = events.Select(n => new jEvents
        //        {
        //            id = n.event_id,
        //            name = n.event_name,
        //            img = n.event_img,
        //            content = n.event_content,
        //            slogan = n.event_slogan,
        //            datecreate = n.event_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.event_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.event_active,
        //            bin = n.event_bin,
        //            option = n.event_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Bin
        //public JsonResult BinEvent(int? id)
        //{
        //    var dao = new EventsDAO();
        //    if (dao.Bin(id))
        //    {
        //        // Giá trị Angular
        //        List<Events> events = db.Events.Where(n => n.event_bin == false).OrderByDescending(n => n.event_datecreate).ToList();
        //        // Tên biến
        //        List<jEvents> list = events.Select(n => new jEvents
        //        {
        //            id = n.event_id,
        //            name = n.event_name,
        //            img = n.event_img,
        //            content = n.event_content,
        //            slogan = n.event_slogan,
        //            datecreate = n.event_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.event_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.event_active,
        //            bin = n.event_bin,
        //            option = n.event_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //public ActionResult IndexBin()
        //{
        //    return View(db.Events.Where(n => n.event_bin == false).ToList());
        //}

        //// Restore
        //public JsonResult RestoreEvent(int? id)
        //{
        //    var dao = new EventsDAO();
        //    if (dao.Restore(id))
        //    {
        //        // Giá trị Angular
        //        List<Events> events = db.Events.Where(n => n.event_bin == true).OrderByDescending(n => n.event_datecreate).ToList();
        //        // Tên biến
        //        List<jEvents> list = events.Select(n => new jEvents
        //        {
        //            id = n.event_id,
        //            name = n.event_name,
        //            img = n.event_img,
        //            content = n.event_content,
        //            slogan = n.event_slogan,
        //            datecreate = n.event_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.event_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.event_active,
        //            bin = n.event_bin,
        //            option = n.event_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Delete
        //public JsonResult DeleteEvent(int? id)
        //{
        //    var dao = new EventsDAO();
        //    if (dao.Delete(id))
        //    {
        //        // Giá trị Angular
        //        List<Events> events = db.Events.Where(n => n.event_bin == true).OrderByDescending(n => n.event_datecreate).ToList();
        //        // Tên biến
        //        List<jEvents> list = events.Select(n => new jEvents
        //        {
        //            id = n.event_id,
        //            name = n.event_name,
        //            img = n.event_img,
        //            content = n.event_content,
        //            slogan = n.event_slogan,
        //            datecreate = n.event_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.event_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.event_active,
        //            bin = n.event_bin,
        //            option = n.event_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}
    }
}