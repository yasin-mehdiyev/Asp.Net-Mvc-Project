using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medway_Pratice.Helpers;
using Medway_Pratice.Models;

namespace Medway_Pratice.Areas.control.Controllers
{
    [Auth]
    [SuperAdminLevel]
    public class RequestsController : Controller
    {
        MedwayEntities db = new MedwayEntities();
        // GET: control/Requests
        public ActionResult Index()
        {
            vwRequest vwRequest = new vwRequest();
            vwRequest.requests = db.Requests.ToList();
            vwRequest.Date = db.Requests.OrderByDescending(d => d.Date).FirstOrDefault();

            return View(vwRequest);
        }
    }
}