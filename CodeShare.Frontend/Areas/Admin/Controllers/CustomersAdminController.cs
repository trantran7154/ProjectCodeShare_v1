using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model;
using CodeShare.Model.DAO;
using CodeShare.Model.EF;
using CodeShare.Common;
using CodeShare.Frontend.Models;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class CustomersAdminController : Controller
    {
        // GET: Admin/CustomersAdmin

        //DataShareCodeEntities db = new DataShareCodeEntities();

        //public ActionResult Index()
        //{
        //    return View(db.Customers.Where(n => n.customer_bin == false).ToList());
        //}

        //// Active
        //public JsonResult ActiveCustomer(int? id)
        //{
        //    var dao = new CustomersDAO();
        //    if (dao.Active(id))
        //    {
        //        // Giá trị Angular
        //        List<Customers> customers = db.Customers.Where(n => n.customer_bin == false).OrderByDescending(n => n.customer_datecreate).ToList();
        //        // Tên biến
        //        List<jCustomers> list = customers.Select(n => new jCustomers
        //        {
        //            id = n.customer_id,
        //            phone = n.customer_phone.ToString(),
        //            favourite = n.customer_favourite.ToString(),
        //            birth = n.customer_birth.Value.ToString("yyyy-MM-dd"),
        //            note = n.customer_note.ToString(),
        //            view = n.customer_view,
        //            address = n.customer_address,
        //            active = n.customer_active,
        //            option = n.customer_option,
        //            datecreate = n.customer_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.customer_update.Value.ToString("yyyy-MM-dd"),
        //            user_id = n.user_id,
        //            user_name = n.Users.user_name
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Option
        //public JsonResult OptionCustomer(int? id)
        //{
        //    var dao = new CustomersDAO();
        //    if (dao.Option(id))
        //    {
        //        // Giá trị Angular
        //        List<Customers> customers = db.Customers.Where(n => n.customer_bin == false).OrderByDescending(n => n.customer_datecreate).ToList();
        //        // Tên biến
        //        List<jCustomers> list = customers.Select(n => new jCustomers
        //        {
        //            id = n.customer_id,
        //            phone = n.customer_phone.ToString(),
        //            favourite = n.customer_favourite.ToString(),
        //            birth = n.customer_birth.Value.ToString("yyyy-MM-dd"),
        //            note = n.customer_note.ToString(),
        //            view = n.customer_view,
        //            address = n.customer_address,
        //            active = n.customer_active,
        //            option = n.customer_option,
        //            datecreate = n.customer_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.customer_update.Value.ToString("yyyy-MM-dd"),
        //            user_id = n.user_id,
        //            user_name = n.Users.user_name
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Bin
        //public JsonResult BinCustomer(int? id)
        //{
        //    var dao = new CustomersDAO();
        //    if (dao.Bin(id))
        //    {
        //        // Giá trị Angular
        //        List<Customers> customers = db.Customers.Where(n => n.customer_bin == false).OrderByDescending(n => n.customer_datecreate).ToList();
        //        // Tên biến
        //        List<jCustomers> list = customers.Select(n => new jCustomers
        //        {
        //            id = n.customer_id,
        //            phone = n.customer_phone.ToString(),
        //            favourite = n.customer_favourite.ToString(),
        //            birth = n.customer_birth.Value.ToString("yyyy-MM-dd"),
        //            note = n.customer_note.ToString(),
        //            view = n.customer_view,
        //            address = n.customer_address,
        //            active = n.customer_active,
        //            option = n.customer_option,
        //            datecreate = n.customer_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.customer_update.Value.ToString("yyyy-MM-dd"),
        //            user_id = n.user_id,
        //            user_name = n.Users.user_name
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //public ActionResult IndexBin()
        //{
        //    return View(db.Customers.Where(n => n.customer_bin == true).ToList());
        //}

        //// Restore
        //public JsonResult RestoreCustomer(int? id)
        //{
        //    var dao = new CustomersDAO();
        //    if (dao.Restore(id))
        //    {
        //        // Giá trị Angular
        //        List<Customers> customers = db.Customers.Where(n => n.customer_bin == true).OrderByDescending(n => n.customer_datecreate).ToList();
        //        // Tên biến
        //        List<jCustomers> list = customers.Select(n => new jCustomers
        //        {
        //            id = n.customer_id,
        //            phone = n.customer_phone.ToString(),
        //            favourite = n.customer_favourite.ToString(),
        //            birth = n.customer_birth.Value.ToString("yyyy-MM-dd"),
        //            note = n.customer_note.ToString(),
        //            view = n.customer_view,
        //            address = n.customer_address,
        //            active = n.customer_active,
        //            option = n.customer_option,
        //            datecreate = n.customer_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.customer_update.Value.ToString("yyyy-MM-dd"),
        //            user_id = n.user_id,
        //            user_name = n.Users.user_name
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}

        //// Delete
        //public JsonResult DeleteCustomer(int? id)
        //{
        //    var dao = new CustomersDAO();
        //    if (dao.Delete(id))
        //    {
        //        // Giá trị Angular
        //        List<Customers> customers = db.Customers.Where(n => n.customer_bin == true).OrderByDescending(n => n.customer_datecreate).ToList();
        //        // Tên biến
        //        List<jCustomers> list = customers.Select(n => new jCustomers
        //        {
        //            id = n.customer_id,
        //            phone = n.customer_phone.ToString(),
        //            favourite = n.customer_favourite.ToString(),
        //            birth = n.customer_birth.Value.ToString("yyyy-MM-dd"),
        //            note = n.customer_note.ToString(),
        //            view = n.customer_view,
        //            address = n.customer_address,
        //            active = n.customer_active,
        //            option = n.customer_option,
        //            datecreate = n.customer_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.customer_update.Value.ToString("yyyy-MM-dd"),
        //            user_id = n.user_id,
        //            user_name = n.Users.user_name
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null);
        //}
    }
}