using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Medway_Pratice.Helpers;

namespace Medway_Pratice.Areas.control.Controllers
{
    [Auth]
    public class DashboardController : Controller
    {
        // GET: control/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}