using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;
using CodeShare.Frontend.Models;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class JsonAdminController : Controller
    {
        // GET: Admin/JsonAdmin
        private CodeShareDataEntities db = new CodeShareDataEntities();

        // Danh sách Danh Mục
        public JsonResult Categorys(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<Categorys> categorys = db.Categorys.Where(n => n.category_bin == false).OrderByDescending(n => n.category_datecreate).ToList();
                // Tên biến
                List<jCategorys> list = categorys.Select(n => new jCategorys
                {
                    id = n.category_id,
                    name = n.category_name,
                    datecreate = n.category_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.category_update.Value.ToString("yyyy-MM-dd"),
                    bin = n.category_bin,
                    active = n.category_active,
                    option = n.category_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<Categorys> categorys = db.Categorys.Where(n => n.category_bin == true).OrderByDescending(n => n.category_datecreate).ToList();
                // Tên biến
                List<jCategorys> list = categorys.Select(n => new jCategorys
                {
                    id = n.category_id,
                    name = n.category_name,
                    datecreate = n.category_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.category_update.Value.ToString("yyyy-MM-dd"),
                    bin = n.category_bin,
                    active = n.category_active,
                    option = n.category_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // Danh sách Banner
        public JsonResult Banners(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<Banners> banners = db.Banners.Where(n => n.banner_bin == false).OrderByDescending(n => n.banner_datecreate).ToList();
                // Tên biến
                List<jBanners> list = banners.Select(n => new jBanners
                {
                    id = n.banner_id,
                    name = n.banner_name,
                    svg = n.banner_svg,
                    datecreate = n.banner_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.banner_update.Value.ToString("yyyy-MM-dd"),
                    active = n.banner_active,
                    bin = n.banner_bin,
                    option = n.banner_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<Banners> banners = db.Banners.Where(n => n.banner_bin == true).OrderByDescending(n => n.banner_datecreate).ToList();
                // Tên biến
                List<jBanners> list = banners.Select(n => new jBanners
                {
                    id = n.banner_id,
                    name = n.banner_name,
                    svg = n.banner_svg,
                    datecreate = n.banner_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.banner_update.Value.ToString("yyyy-MM-dd"),
                    active = n.banner_active,
                    bin = n.banner_bin,
                    option = n.banner_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // Danh sách Chat
        public JsonResult Chats(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<Chats> chats = db.Chats.Where(n => n.chat_bin == false).OrderByDescending(n => n.chat_datecreate).ToList();
                // Tên biến
                List<jChats> list = chats.Select(n => new jChats
                {
                    id = n.chat_id,
                    content = n.chat_content,
                    datecreate = n.chat_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.chat_update.Value.ToString("yyyy-MM-dd"),
                    active = n.chat_active,
                    bin = n.chat_bin,
                    option = n.chat_option,
                    idtake = n.chat_idtake,
                    send = n.chat_send,
                    stt = n.chat_stt
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<Chats> chats = db.Chats.Where(n => n.chat_bin == true).OrderByDescending(n => n.chat_datecreate).ToList();
                // Tên biến
                List<jChats> list = chats.Select(n => new jChats
                {
                    id = n.chat_id,
                    content = n.chat_content,
                    datecreate = n.chat_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.chat_update.Value.ToString("yyyy-MM-dd"),
                    active = n.chat_active,
                    bin = n.chat_bin,
                    option = n.chat_option,
                    idtake = n.chat_idtake,
                    send = n.chat_send,
                    stt = n.chat_stt
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // Danh sách Code
        public JsonResult Codes(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<Codes> codes = db.Codes.Where(n => n.code_bin == false).OrderByDescending(n => n.code_datecreate).ToList();
                // Tên biến
                List<jCodes> list = codes.Select(n => new jCodes
                {
                    id = n.code_id,
                    name = n.code_name,
                    img = n.code_img,
                    description = n.code_description,
                    capacity = n.code_capacity,
                    link = n.code_link,
                    coin = n.code_coin,
                    view = n.code_view,
                    datecreate = n.code_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.code_update.Value.ToString("yyyy-MM-dd"),
                    active = n.code_active,
                    bin = n.code_bin,
                    option = n.code_option,
                    introduce = n.code_introduce,
                    down = n.code_down,
                    browser_demo = n.code_browser_demo,
                    demo = n.code_demo,
                    point_refer = n.code_point_refer,
                    browser_quality = n.code_browser_quality,
                    point_quality = n.code_point_quality,
                    browser_downoad = n.code_browser_downoad,
                    browser_error = n.code_browser_error,
                    banner_id = n.banner_id,
                    form_id = n.form_id,
                    user_id = n.user_id,
                    user_name = n.code_name
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<Codes> codes = db.Codes.Where(n => n.code_bin == true).OrderByDescending(n => n.code_datecreate).ToList();
                // Tên biến
                List<jCodes> list = codes.Select(n => new jCodes
                {
                    id = n.code_id,
                    name = n.code_name,
                    img = n.code_img,
                    description = n.code_description,
                    capacity = n.code_capacity,
                    link = n.code_link,
                    coin = n.code_coin,
                    view = n.code_view,
                    datecreate = n.code_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.code_update.Value.ToString("yyyy-MM-dd"),
                    active = n.code_active,
                    bin = n.code_bin,
                    option = n.code_option,
                    introduce = n.code_introduce,
                    down = n.code_down,
                    browser_demo = n.code_browser_demo,
                    demo = n.code_demo,
                    point_refer = n.code_point_refer,
                    browser_quality = n.code_browser_quality,
                    point_quality = n.code_point_quality,
                    browser_downoad = n.code_browser_downoad,
                    browser_error = n.code_browser_error,
                    banner_id = n.banner_id,
                    form_id = n.form_id,
                    user_id = n.user_id,
                    user_name = n.code_name
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // Danh sách khóa học
        public JsonResult Courses(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<Courses> courses = db.Courses.Where(n => n.course_bin == false).OrderByDescending(n => n.course_datecreate).ToList();
                // Tên biến
                List<jCourses> list = courses.Select(n => new jCourses
                {
                    id = n.course_id,
                    name = n.course_name,
                    img = n.course_img,
                    content = n.course_content,
                    view = n.course_view,
                    datecreate = n.course_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.course_update.Value.ToString("yyyy-MM-dd"),
                    active = n.course_active,
                    bin = n.course_bin,
                    option = n.course_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<Courses> courses = db.Courses.Where(n => n.course_bin == true).OrderByDescending(n => n.course_datecreate).ToList();
                // Tên biến
                List<jCourses> list = courses.Select(n => new jCourses
                {
                    id = n.course_id,
                    name = n.course_name,
                    img = n.course_img,
                    content = n.course_content,
                    view = n.course_view,
                    datecreate = n.course_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.course_update.Value.ToString("yyyy-MM-dd"),
                    active = n.course_active,
                    bin = n.course_bin,
                    option = n.course_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // Danh sách thông tin khách hàng
        public JsonResult Customers(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<Customers> customers = db.Customers.Where(n => n.customer_bin == false).OrderByDescending(n => n.customer_datecreate).ToList();
                // Tên biến
                List<jCustomers> list = customers.Select(n => new jCustomers
                {
                    id = n.customer_id,
                    phone = n.customer_phone.ToString(),
                    favourite = n.customer_favourite.ToString(),
                    birth = n.customer_birth.Value.ToString("yyyy-MM-dd"),
                    note = n.customer_note.ToString(),
                    view = n.customer_view,
                    address = n.customer_address,
                    active = n.customer_active,
                    option = n.customer_option,
                    datecreate = n.customer_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.customer_update.Value.ToString("yyyy-MM-dd"),
                    user_id = n.user_id,
                    user_name = n.Users.user_name
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<Customers> customers = db.Customers.Where(n => n.customer_bin == true).OrderByDescending(n => n.customer_datecreate).ToList();
                // Tên biến
                List<jCustomers> list = customers.Select(n => new jCustomers
                {
                    id = n.customer_id,
                    phone = n.customer_phone.ToString(),
                    favourite = n.customer_favourite.ToString(),
                    birth = n.customer_birth.Value.ToString("yyyy-MM-dd"),
                    note = n.customer_note.ToString(),
                    view = n.customer_view,
                    address = n.customer_address,
                    active = n.customer_active,
                    option = n.customer_option,
                    datecreate = n.customer_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.customer_update.Value.ToString("yyyy-MM-dd"),
                    user_id = n.user_id,
                    user_name = n.Users.user_name
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // Danh sách mệnh giá xu
        public JsonResult Denominations(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<Denominations> denominations = db.Denominations.Where(n => n.denomination_bin == false).OrderByDescending(n => n.denomination_datecreate).ToList();
                // Tên biến
                List<jDenominations> list = denominations.Select(n => new jDenominations
                {
                    id = n.denomination_id,
                    price = n.denomination_price,
                    coin = n.denomination_coin,
                    datecreate = n.denomination_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.denomination_update.Value.ToString("yyyy-MM-dd"),
                    active = n.denomination_active,
                    bin = n.denomination_bin,
                    option = n.denomination_option,
                    content = n.denomination_content
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<Denominations> denominations = db.Denominations.Where(n => n.denomination_bin == true).OrderByDescending(n => n.denomination_datecreate).ToList();
                // Tên biến
                List<jDenominations> list = denominations.Select(n => new jDenominations
                {
                    id = n.denomination_id,
                    price = n.denomination_price.ToString(),
                    coin = n.denomination_coin,
                    datecreate = n.denomination_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.denomination_update.Value.ToString("yyyy-MM-dd"),
                    active = n.denomination_active,
                    bin = n.denomination_bin,
                    option = n.denomination_option,
                    content = n.denomination_content
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // Danh sách sự kiện
        public JsonResult Events(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<Events> events = db.Events.Where(n => n.event_bin == false).OrderByDescending(n => n.event_datecreate).ToList();
                // Tên biến
                List<jEvents> list = events.Select(n => new jEvents
                {
                    id = n.event_id,
                    name = n.event_name,
                    img = n.event_img,
                    content = n.event_content,
                    slogan = n.event_slogan,
                    datecreate = n.event_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.event_update.Value.ToString("yyyy-MM-dd"),
                    active = n.event_active,
                    bin = n.event_bin,
                    option = n.event_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<Events> events = db.Events.Where(n => n.event_bin == true).OrderByDescending(n => n.event_datecreate).ToList();
                // Tên biến
                List<jEvents> list = events.Select(n => new jEvents
                {
                    id = n.event_id,
                    name = n.event_name,
                    img = n.event_img,
                    content = n.event_content,
                    slogan = n.event_slogan,
                    datecreate = n.event_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.event_update.Value.ToString("yyyy-MM-dd"),
                    active = n.event_active,
                    bin = n.event_bin,
                    option = n.event_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // Danh sách danh mục kiến thức lập trình
        public JsonResult Knowledge_Categorys(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<Knowledge_Categorys> kc = db.Knowledge_Categorys.Where(n => n.kc_bin == false).OrderByDescending(n => n.kc_datecreate).ToList();
                // Tên biến
                List<jKC> list = kc.Select(n => new jKC
                {
                    id = n.kc_id,
                    name = n.kc_name,
                    datecreate = n.kc_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.kc_update.Value.ToString("yyyy-MM-dd"),
                    active = n.kc_active,
                    bin = n.kc_bin,
                    option = n.kc_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<Knowledge_Categorys> kc = db.Knowledge_Categorys.Where(n => n.kc_bin == true).OrderByDescending(n => n.kc_datecreate).ToList();
                // Tên biến
                List<jKC> list = kc.Select(n => new jKC
                {
                    id = n.kc_id,
                    name = n.kc_name,
                    datecreate = n.kc_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.kc_update.Value.ToString("yyyy-MM-dd"),
                    active = n.kc_active,
                    bin = n.kc_bin,
                    option = n.kc_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // Danh sách danh kiến thức lập trình
        public JsonResult Programming_Knowledges(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<Programming_Knowledges> pk = db.Programming_Knowledges.Where(n => n.pk_bin == false).OrderByDescending(n => n.pk_datecreate).ToList();
                // Tên biến
                List<jPK> list = pk.Select(n => new jPK
                {
                    id = n.pk_id,
                    name = n.pk_name,
                    img = n.pk_img,
                    content = n.pk_content,
                    datecreate = n.pk_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.pk_update.Value.ToString("yyyy-MM-dd"),
                    active = n.pk_active,
                    bin = n.pk_bin,
                    option = n.pk_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<Programming_Knowledges> pk = db.Programming_Knowledges.Where(n => n.pk_bin == true).OrderByDescending(n => n.pk_datecreate).ToList();
                // Tên biến
                List<jPK> list = pk.Select(n => new jPK
                {
                    id = n.pk_id,
                    name = n.pk_name,
                    img = n.pk_img,
                    content = n.pk_content,
                    datecreate = n.pk_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.pk_update.Value.ToString("yyyy-MM-dd"),
                    active = n.pk_active,
                    bin = n.pk_bin,
                    option = n.pk_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // Danh sách danh người dùng
        public JsonResult Users(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<Users> users = db.Users.Where(n => n.user_bin== false).OrderByDescending(n => n.user_datecreate).ToList();
                // Tên biến
                List<jUsers> list = users.Select(n => new jUsers
                {
                    id = n.user_id,
                    name = n.user_name,
                    img = n.user_img,
                    email = n.user_email,
                    pass = n.user_pass,
                    coin = n.user_coin,
                    code = n.user_code,
                    token = Guid.NewGuid().ToString(),
                    datecreate = n.user_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.user_update.Value.ToString("yyyy-MM-dd"),
                    datelogin = n.user_datelogin.Value.ToString("yyyy-MM-dd"),
                    active = n.user_active,
                    bin = n.user_bin,
                    option = n.user_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<Users> users = db.Users.Where(n => n.user_bin == true).OrderByDescending(n => n.user_datecreate).ToList();
                // Tên biến
                List<jUsers> list = users.Select(n => new jUsers
                {
                    id = n.user_id,
                    name = n.user_name,
                    img = n.user_img,
                    email = n.user_email,
                    pass = n.user_pass,
                    coin = n.user_coin,
                    code = "#CODE" + n.user_id,
                    token = Guid.NewGuid().ToString(),
                    datecreate = n.user_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.user_update.Value.ToString("yyyy-MM-dd"),
                    datelogin = n.user_datelogin.Value.ToString("yyyy-MM-dd"),
                    active = n.user_active,
                    bin = n.user_bin,
                    option = n.user_option
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // Danh sách rút tiền
        public JsonResult Withdrawals(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<Withdrawals> withdrawals = db.Withdrawals.Where(n => n.withdrawal_bin == false).OrderByDescending(n => n.withdrawal_datecreate).ToList();
                // Tên biến
                List<jWithdrawals> list = withdrawals.Select(n => new jWithdrawals
                {
                    id = n.withdrawal_id,
                    coin = n.withdrawal_coin,
                    datecreate = n.withdrawal_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.withdrawal_update.Value.ToString("yyyy-MM-dd"),
                    email = n.withdrawal_email,
                    tel = n.withdrawal_tel,
                    active = n.withdrawal_active,
                    bin = n.withdrawal_bin,
                    option = n.withdrawal_option,
                    user_id = n.user_id,
                    user_name = n.Users.user_name
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<Withdrawals> withdrawals = db.Withdrawals.Where(n => n.withdrawal_bin == true).OrderByDescending(n => n.withdrawal_datecreate).ToList();
                // Tên biến
                List<jWithdrawals> list = withdrawals.Select(n => new jWithdrawals
                {
                    id = n.withdrawal_id,
                    coin = n.withdrawal_coin,
                    datecreate = n.withdrawal_datecreate.Value.ToString("yyyy-MM-dd"),
                    update = n.withdrawal_update.Value.ToString("yyyy-MM-dd"),
                    email = n.withdrawal_email,
                    tel = n.withdrawal_tel,
                    active = n.withdrawal_active,
                    bin = n.withdrawal_bin,
                    option = n.withdrawal_option,
                    user_id = n.user_id,
                    user_name = n.Users.user_name
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }
    }
}