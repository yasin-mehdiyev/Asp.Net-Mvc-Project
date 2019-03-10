using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medway_Pratice.Models;

namespace Medway_Pratice.Controllers
{
    public class HomeController : baseController
    {
        public ActionResult Index()
        {
            vwHome vwHome = new vwHome
            {
                Services = db.Services.OrderBy(s => s.OrderBy).ToList(),
                Sliders=db.Sliders.OrderBy(s=>s.OrderBy).ToList(),
                Features=db.Features.OrderBy(f=>f.OrderBy).ToList(),
                Blogs=db.Blogs.OrderByDescending(b=>b.Date).Take(3).ToList()
            };
            return View(vwHome);
        }

        [HttpPost]
        public ActionResult Send(Request request)
        {
            request.Date = DateTime.Now;
            db.Requests.Add(request);
            db.SaveChanges();
            return RedirectToAction("index", "home");
        }

    }
}