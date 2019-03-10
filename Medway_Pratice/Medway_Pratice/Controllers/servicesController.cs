using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medway_Pratice.Models;

namespace Medway_Pratice.Controllers
{
    public class servicesController : baseController
    {
        // GET: services
        public ActionResult Index()
        {
            return View(db.Services.OrderBy(s=>s.OrderBy).ToList());
        }
        public ActionResult Read(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }

            Service service = db.Services.Find(id);

            if (service==null)
            {
                return HttpNotFound();
            }

            return View(service);
        }
    }
}