using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medway_Pratice.Models;


namespace Medway_Pratice.Helpers
{
    public class Auth:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Logined"] == null)
            {
                filterContext.Result = new RedirectResult("~/control");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

    }
}