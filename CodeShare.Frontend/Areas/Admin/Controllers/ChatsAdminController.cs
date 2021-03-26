using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;
using CodeShare.Model.DAO;
using CodeShare.Frontend.Models;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class ChatsAdminController : Controller
    {
        // GET: Admin/ChatsAdmin
        //DataShareCodeEntities db = new DataShareCodeEntities();

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// Active
        //public JsonResult BinChat(int? id)
        //{
        //    var dao = new ChatsDAO();
        //    if (dao.Bin(id))
        //    {
        //        // Giá trị Angular
        //        List<Chats> chats = db.Chats.Where(n => n.chat_bin == false).OrderByDescending(n => n.chat_datecreate).ToList();
        //        // Tên biến
        //        List<jChats> list = chats.Select(n => new jChats
        //        {
        //            id = n.chat_id,
        //            content = n.chat_content,
        //            datecreate = n.chat_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.chat_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.chat_active,
        //            bin = n.chat_bin,
        //            option = n.chat_option,
        //            idtake = n.chat_idtake,
        //            send = n.chat_send,
        //            stt = n.chat_stt
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Active
        //public JsonResult ActiveChat(int? id)
        //{
        //    var dao = new ChatsDAO();
        //    if (dao.Active(id))
        //    {
        //        // Giá trị Angular
        //        List<Chats> chats = db.Chats.Where(n => n.chat_bin == false).OrderByDescending(n => n.chat_datecreate).ToList();
        //        // Tên biến
        //        List<jChats> list = chats.Select(n => new jChats
        //        {
        //            id = n.chat_id,
        //            content = n.chat_content,
        //            datecreate = n.chat_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.chat_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.chat_active,
        //            bin = n.chat_bin,
        //            option = n.chat_option,
        //            idtake = n.chat_idtake,
        //            send = n.chat_send,
        //            stt = n.chat_stt
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Option
        //public JsonResult OptionChat(int? id)
        //{
        //    var dao = new ChatsDAO();
        //    if (dao.Option(id))
        //    {
        //        // Giá trị Angular
        //        List<Chats> chats = db.Chats.Where(n => n.chat_bin == false).OrderByDescending(n => n.chat_datecreate).ToList();
        //        // Tên biến
        //        List<jChats> list = chats.Select(n => new jChats
        //        {
        //            id = n.chat_id,
        //            content = n.chat_content,
        //            datecreate = n.chat_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.chat_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.chat_active,
        //            bin = n.chat_bin,
        //            option = n.chat_option,
        //            idtake = n.chat_idtake,
        //            send = n.chat_send,
        //            stt = n.chat_stt
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //public ActionResult IndexBin()
        //{
        //    return View(db.Chats.Where(n => n.chat_bin == true).ToList());
        //}

        //// Delete
        //public JsonResult DeleteChat(int? id)
        //{
        //    var dao = new ChatsDAO();
        //    if (dao.Delete(id))
        //    {
        //        // Giá trị Angular
        //        List<Chats> chats = db.Chats.Where(n => n.chat_bin == true).OrderByDescending(n => n.chat_datecreate).ToList();
        //        // Tên biến
        //        List<jChats> list = chats.Select(n => new jChats
        //        {
        //            id = n.chat_id,
        //            content = n.chat_content,
        //            datecreate = n.chat_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.chat_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.chat_active,
        //            bin = n.chat_bin,
        //            option = n.chat_option,
        //            idtake = n.chat_idtake,
        //            send = n.chat_send,
        //            stt = n.chat_stt
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Restore
        //public JsonResult RestoreChat(int? id)
        //{
        //    var dao = new ChatsDAO();
        //    if (dao.Restore(id))
        //    {
        //        // Giá trị Angular
        //        List<Chats> chats = db.Chats.Where(n => n.chat_bin == true).OrderByDescending(n => n.chat_datecreate).ToList();
        //        // Tên biến
        //        List<jChats> list = chats.Select(n => new jChats
        //        {
        //            id = n.chat_id,
        //            content = n.chat_content,
        //            datecreate = n.chat_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.chat_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.chat_active,
        //            bin = n.chat_bin,
        //            option = n.chat_option,
        //            idtake = n.chat_idtake,
        //            send = n.chat_send,
        //            stt = n.chat_stt
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}
    }
}