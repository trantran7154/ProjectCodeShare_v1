using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeShare.Frontend.Controllers
{
    public class ViewController : Controller
    {
        // Menu
        public PartialViewResult Menu()
        {
            return PartialView();
        }

        public PartialViewResult Error()
        {
            return PartialView();
        }

        public PartialViewResult Header()
        {
            return PartialView();
        }
        public PartialViewResult All()
        {
            return PartialView();
        }
    }
}