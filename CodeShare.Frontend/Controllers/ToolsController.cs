using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Frontend.Hubs;
using CodeShare.Frontend.Functions;
using CodeShare.Model.EF;
using CodeShare.Frontend.Models;

namespace CodeShare.Frontend.Controllers
{
    public class ToolsController : Controller
    {
        DataShareCodeEntities db = new DataShareCodeEntities();
        FunctionsController functions = new FunctionsController();
        // GET: Tools
        public ActionResult Chats(int ? id)
        {
            return View(db.Users.Find(id));
        }
        public JsonResult Create(int ? id, string content)
        {

            var cookie = functions.CookieID();

            Chat chat = new Chat
            {
                chat_content = content,
                chat_datecreate = DateTime.Now,
                user_id = id
            };
            db.Chats.Add(chat);
            db.SaveChanges();
            return Json(null);
        }
        //Json chat - co the cap lai theo js
        public JsonResult Get(int? id)
        {
            var cookie = functions.CookieID();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataShareCode"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT [chat_id],[user_id],[chat_content],[chat_datecreate]FROM [dbo].[Chats]", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    SqlDataReader reader = command.ExecuteReader();



                    List<Chat> Chat = db.Chats.Where(n=>n.user_id == id && n.id_send == cookie.user_id).OrderByDescending(n=>n.chat_datecreate).ToList();

                    return Json(new { listChat = Chat }, JsonRequestBehavior.AllowGet);

                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            ChatHub.Show();
        }
    }
}