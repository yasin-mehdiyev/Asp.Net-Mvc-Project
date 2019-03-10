using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medway_Pratice.Models;

namespace Medway_Pratice.Controllers
{
    public class baseController : Controller
    {
        protected MedwayEntities db = new MedwayEntities();

        public baseController()
        {
            ViewBag.Setting = db.Settings.FirstOrDefault();
            ViewBag.Services = db.Services.OrderBy(s => s.OrderBy).ToList();
            ViewBag.Partners = db.Partners.OrderBy(p => p.OrderBy).ToList();
        }

     
    }
}