using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class ViewAdminController : Controller
    {
        // GET: Admin/View
        public PartialViewResult Statistical()
        {
            return PartialView();
        }
        public PartialViewResult Header()
        {
            return PartialView();
        }
        public PartialViewResult Menu()
        {
            return PartialView();
        }
        public PartialViewResult SayHi()
        {
            return PartialView();
        }
    }
}