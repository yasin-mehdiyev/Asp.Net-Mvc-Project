using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medway_Pratice.Models;

namespace Medway_Pratice.Controllers
{
    public class aboutusController : baseController
    {
        // GET: aboutUs
        public ActionResult Index()
        {
            vwAbout vwAbout = new vwAbout
            {
                about=db.Abouts.FirstOrDefault(),
                aboutPhotos=db.AboutPhotos.OrderBy(ap=>ap.OrderBy).ToList()
            };

            return View(vwAbout);
        }
    }
}