using System.Web.Mvc;

namespace Medway_Pratice.Areas.control
{
    public class controlAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "control";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "control_default",
                "control/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Medway_Pratice.Areas.control.Controllers" }
            );
        }
    }
}