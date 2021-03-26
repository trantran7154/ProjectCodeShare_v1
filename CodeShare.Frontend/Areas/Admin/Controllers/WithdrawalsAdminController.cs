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

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class WithdrawalsAdminController : Controller
    {
        // GET: Admin/WithdrawalsAdmin

        CodeShareDataEntities db = new CodeShareDataEntities();

        public ActionResult Index()
        {
            return View();
        }

        // Active
        public JsonResult ActiveWidthdrawal(int? id)
        {
            var dao = new WithdrawalsDAO();
            if (dao.Active(id))
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
            return Json(null);
        }

        // Option
        public JsonResult OptionWidthdrawal(int? id)
        {
            var dao = new WithdrawalsDAO();
            if (dao.Option(id))
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
            return Json(null);
        }
    }
}