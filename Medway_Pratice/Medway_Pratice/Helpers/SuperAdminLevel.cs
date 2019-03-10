using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medway_Pratice.Models;

namespace Medway_Pratice.Helpers
{
    public class SuperAdminLevel:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Admin admin = HttpContext.Current.Session["Admin"] as Admin;

            if (admin.Level!=0)
            {
                HttpContext.Current.Session["AdminLevel"] = "Sizin bura girməyə səlahiyyətiniz yoxdur";
                filterContext.Result = new RedirectResult("~/control/dashboard");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}