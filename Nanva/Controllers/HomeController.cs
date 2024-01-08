using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nanva.Controllers
{
    public class HomeController : PublicController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}