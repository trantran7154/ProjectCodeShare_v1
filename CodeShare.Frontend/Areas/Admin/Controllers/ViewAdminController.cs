using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Model.EF;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class ViewAdminController : Controller
    {
        DataShareCodeEntities db = new DataShareCodeEntities();
        // GET: Admin/View
        public PartialViewResult Statistical()
        {
            return PartialView();
        }
        public PartialViewResult Header()
        {
            return PartialView();
        }
        public PartialViewResult Menu(string key)
        {
            ViewBag.Title = key;
            return PartialView();
        }
        public PartialViewResult SayHi()
        {
            return PartialView();
        }
        //Quản lý doanh thu
        public ActionResult StaticPrice()
        {
            return View();
        }
        //History
        public JsonResult GetHistory(int? id)
        {
            HttpCookie cookie = Request.Cookies["admin_id"];

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataShareCode"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT [his_id]
                      ,[user_id]
                      ,[his_datecreate]
                      ,[his_content]
                  FROM [dbo].[Historys]", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    var list = db.Historys.OrderByDescending(n=>n.his_datecreate).Select(n=> new { 
                        content = n.his_content,
                        img = n.User.user_img,
                        date = n.his_datecreate.Value.ToString()
                    
                    }).ToList();

                    return Json(new { list = list }, JsonRequestBehavior.AllowGet);

                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            Hubs.HistoryHub.Show();
        }
    }
}