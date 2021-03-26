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
        private DataShareCodeEntities db = new DataShareCodeEntities();

        // Danh sách Danh Mục
        public JsonResult Categorys(string del)
        {
            // Giá trị Angular
            List<Category> categorys = db.Categorys.ToList();
            // Tên biến
            List<jCategorys> list = categorys.Select(n => new jCategorys
            {
                active = n.category_active,
                id = n.category_id,
                item = (int)n.category_item,
                name = n.category_name.ToString()
            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Danh sách Banner
        //public JsonResult Banners(string del)
        //{
        //    if (del != "del")
        //    {
        //        // Giá trị Angular
        //        List<Banners> banners = db.Banners.Where(n => n.banner_bin == false).OrderByDescending(n => n.banner_datecreate).ToList();
        //        // Tên biến
        //        List<jBanners> list = banners.Select(n => new jBanners
        //        {
        //            id = n.banner_id,
        //            name = n.banner_name,
        //            svg = n.banner_svg,
        //            datecreate = n.banner_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.banner_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.banner_active,
        //            bin = n.banner_bin,
        //            option = n.banner_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        // Giá trị Angular
        //        List<Banners> banners = db.Banners.Where(n => n.banner_bin == true).OrderByDescending(n => n.banner_datecreate).ToList();
        //        // Tên biến
        //        List<jBanners> list = banners.Select(n => new jBanners
        //        {
        //            id = n.banner_id,
        //            name = n.banner_name,
        //            svg = n.banner_svg,
        //            datecreate = n.banner_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.banner_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.banner_active,
        //            bin = n.banner_bin,
        //            option = n.banner_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //}

        // Danh sách Chat
        //public JsonResult Chats(string del)
        //{
        //    if (del != "del")
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
        //    else
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
        //}

        // Danh sách Code
        public JsonResult Codes(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<Code> codes = db.Codes.Where(n => n.code_del == false).OrderByDescending(n => n.code_datecreate).ToList();
                // Tên biến
                List<jCodes> list = codes.Select(n => new jCodes
                {
                    id = n.code_id,
                    active = (int)n.code_active,
                    code = n.code_code.ToString(),
                    coin = (int)n.code_coin,
                    datecreate = n.code_datecreate.Value.ToString("dd/MM/yyyy"),
                    dateupdate = n.code_dateupdate.Value.ToString("dd/MM/yyyy"),
                    del = n.code_del,
                    des = n.code_des,
                    disk = (int)n.code_disk,
                    id_cate = (int)n.category_id,
                    id_us = (int)n.user_id,
                    img = n.code_img.ToString(),
                    info = n.code_info.ToString(),
                    linkdemo = n.code_linkdemo.ToString(),
                    linkdown = n.code_linkdown.ToString(),
                    option = n.code_option,
                    pass = n.code_pass.ToString(),
                    setting = n.code_setting.ToString(),
                    tag = n.code_tag.ToString(),
                    title = n.code_title.ToString(),
                    view = (int)n.code_view,
                    viewdown = (int)n.code_viewdown
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<Code> codes = db.Codes.Where(n => n.code_del == true).OrderByDescending(n => n.code_datecreate).ToList();
                // Tên biến
                List<jCodes> list = codes.Select(n => new jCodes
                {
                    id = n.code_id,
                    active = (int)n.code_active,
                    code = n.code_code.ToString(),
                    coin = (int)n.code_coin,
                    datecreate = n.code_datecreate.Value.ToString("dd/MM/yyyy"),
                    dateupdate = n.code_dateupdate.Value.ToString("dd/MM/yyyy"),
                    del = n.code_del,
                    des = n.code_des,
                    disk = (int)n.code_disk,
                    id_cate = (int)n.category_id,
                    id_us = (int)n.user_id,
                    img = n.code_img.ToString(),
                    info = n.code_info.ToString(),
                    linkdemo = n.code_linkdemo.ToString(),
                    linkdown = n.code_linkdown.ToString(),
                    option = n.code_option,
                    pass = n.code_pass.ToString(),
                    setting = n.code_setting.ToString(),
                    tag = n.code_tag.ToString(),
                    title = n.code_title.ToString(),
                    view = (int)n.code_view,
                    viewdown = (int)n.code_viewdown
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // Danh sách khóa học
        //public JsonResult Courses(string del)
        //{
        //    if (del != "del")
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
        //}

        // Danh sách thông tin khách hàng
        //public JsonResult Customers(string del)
        //{
        //    if (del != "del")
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
        //    else
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
        //}

        // Danh sách mệnh giá xu
        public JsonResult Denominations(string del)
        {
            // Giá trị Angular
            List<Pakage> denominations = db.Pakages.ToList();
            // Tên biến
            List<jPakages> list = denominations.Select(n => new jPakages
            {
                active = (int)n.pakage_active,
                coin = (int)n.pakage_coin,
                id = n.pakege_id,
                money = n.pakage_money
            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Danh sách sự kiện
        //public JsonResult Events(string del)
        //{
        //    if (del != "del")
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
        //    else
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
        //}

        // Danh sách danh mục kiến thức lập trình
        //public JsonResult Knowledge_Categorys(string del)
        //{
        //    if (del != "del")
        //    {
        //        // Giá trị Angular
        //        List<Knowledge_Categorys> kc = db.Knowledge_Categorys.Where(n => n.kc_bin == false).OrderByDescending(n => n.kc_datecreate).ToList();
        //        // Tên biến
        //        List<jKC> list = kc.Select(n => new jKC
        //        {
        //            id = n.kc_id,
        //            name = n.kc_name,
        //            datecreate = n.kc_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.kc_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.kc_active,
        //            bin = n.kc_bin,
        //            option = n.kc_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        // Giá trị Angular
        //        List<Knowledge_Categorys> kc = db.Knowledge_Categorys.Where(n => n.kc_bin == true).OrderByDescending(n => n.kc_datecreate).ToList();
        //        // Tên biến
        //        List<jKC> list = kc.Select(n => new jKC
        //        {
        //            id = n.kc_id,
        //            name = n.kc_name,
        //            datecreate = n.kc_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.kc_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.kc_active,
        //            bin = n.kc_bin,
        //            option = n.kc_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //}

        // Danh sách danh kiến thức lập trình
        //public JsonResult Programming_Knowledges(string del)
        //{
        //    if (del != "del")
        //    {
        //        // Giá trị Angular
        //        List<Programming_Knowledges> pk = db.Programming_Knowledges.Where(n => n.pk_bin == false).OrderByDescending(n => n.pk_datecreate).ToList();
        //        // Tên biến
        //        List<jPK> list = pk.Select(n => new jPK
        //        {
        //            id = n.pk_id,
        //            name = n.pk_name,
        //            img = n.pk_img,
        //            content = n.pk_content,
        //            datecreate = n.pk_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.pk_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.pk_active,
        //            bin = n.pk_bin,
        //            option = n.pk_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        // Giá trị Angular
        //        List<Programming_Knowledges> pk = db.Programming_Knowledges.Where(n => n.pk_bin == true).OrderByDescending(n => n.pk_datecreate).ToList();
        //        // Tên biến
        //        List<jPK> list = pk.Select(n => new jPK
        //        {
        //            id = n.pk_id,
        //            name = n.pk_name,
        //            img = n.pk_img,
        //            content = n.pk_content,
        //            datecreate = n.pk_datecreate.Value.ToString("yyyy-MM-dd"),
        //            update = n.pk_update.Value.ToString("yyyy-MM-dd"),
        //            active = n.pk_active,
        //            bin = n.pk_bin,
        //            option = n.pk_option
        //        }).ToList();
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //}

        // Danh sách danh người dùng
        public JsonResult Users(string del)
        {
            if (del != "del")
            {
                // Giá trị Angular
                List<User> users = db.Users.Where(n => n.user_del == false).OrderByDescending(n => n.user_datecreate).ToList();
                // Tên biến
                List<jUsers> list = users.Select(n => new jUsers
                {
                    id = n.user_id,
                    name = n.user_name,
                    view = (int)n.user_view,
                    active = (int)n.user_active,
                    birth = n.user_birth.ToString(),
                    code = n.user_code.ToString(),
                    coin = (int)n.user_coin,
                    datecreate = n.user_datecreate.Value.ToString("dd/MM/yyyy"),
                    dateupdate = n.user_dateupdate.Value.ToString("dd/MM/yyy"),
                    del = n.user_del,
                    email = n.user_email.ToString(),
                    fa = n.user_fa.ToString(),
                    facode = n.user_facode,
                    none = n.user_none,
                    option = n.user_option,
                    phone = n.user_phone.ToString(),
                    role = (int)n.user_role,
                    sex = n.user_sex,
                    token = n.user_token.ToString()
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Giá trị Angular
                List<User> users = db.Users.Where(n => n.user_del == true).OrderByDescending(n => n.user_datecreate).ToList();
                // Tên biến
                List<jUsers> list = users.Select(n => new jUsers
                {
                    id = n.user_id,
                    name = n.user_name,
                    view = (int)n.user_view,
                    active = (int)n.user_active,
                    birth = n.user_birth.ToString(),
                    code = n.user_code.ToString(),
                    coin = (int)n.user_coin,
                    datecreate = n.user_datecreate.Value.ToString("dd/MM/yyyy"),
                    dateupdate = n.user_dateupdate.Value.ToString("dd/MM/yyy"),
                    del = n.user_del,
                    email = n.user_email.ToString(),
                    fa = n.user_fa.ToString(),
                    facode = n.user_facode,
                    none = n.user_none,
                    option = n.user_option,
                    phone = n.user_phone.ToString(),
                    role = (int)n.user_role,
                    sex = n.user_sex,
                    token = n.user_token.ToString()
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // Danh sách rút tiền
        public JsonResult Withdrawals(string del)
        {
            // Giá trị Angular
            List<TakePrice> withdrawals = db.TakePrices.OrderByDescending(n => n.tp_datecreate).ToList();
            // Tên biến
            List<jTakePrices> list = withdrawals.Select(n => new jTakePrices
            {
                active = (int)n.tp_active,
                coin = (int)n.tp_coin,
                datecreate = n.tp_datecreate.Value.ToString("dd/MM/yyyy"),
                id = n.tp_id,
                id_us = (int)n.user_id,
                note = n.tp_note.ToString()
            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}