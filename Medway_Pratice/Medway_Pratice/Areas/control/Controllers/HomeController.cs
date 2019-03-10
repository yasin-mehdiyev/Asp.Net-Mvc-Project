using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Medway_Pratice.Models;

namespace Medway_Pratice.Areas.control.Controllers
{
    public class HomeController : Controller
    {
      private readonly MedwayEntities db = new MedwayEntities();
        // GET: control/Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            //Datalar daxil edilmədən giriş eləmək isdədikdə baş verən action

            if (string.IsNullOrEmpty(admin.Email) || string.IsNullOrEmpty(admin.Password))
            {
                Session["LoginedError"] = "E-poçt və ya Şifrəniz yazılmayıb";
                return RedirectToAction("index");
            }


            //Email və Password datalari duz daxil edildikdə olan action

            Admin adm = db.Admins.FirstOrDefault(a => a.Email == admin.Email);

            if (adm!=null)
            {
                if (Crypto.VerifyHashedPassword(adm.Password,admin.Password))
                {
                    Session["Logined"] = true;
                    Session["Admin"] = adm;
                    return RedirectToAction("index", "dashboard");
                }
            }

            //Dataları Səhv daxil etmə hissəsində baş verən action

            Session["LoginedError"] = "E-poçt və ya Şifrəniz səhvdir";
            return RedirectToAction("index");

        }

        public ActionResult Logout()
        {
            Session["Logined"] = null;
            return RedirectToAction("index");
        }
    }
}