using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class ViewController : Controller
    {
        // GET: Admin/View
        public PartialViewResult Statistical()
        {
            return PartialView();
        }
    }
}