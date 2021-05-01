using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeShare.Frontend.Areas.Admin.Controllers
{
    public class ValidationController : Controller
    {
        // GET: Admin/Validation
        public PartialViewResult Index()
        {
            return PartialView();
        }
    }
}