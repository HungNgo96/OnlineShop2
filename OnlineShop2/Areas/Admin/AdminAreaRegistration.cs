using System.Web.Mvc;

namespace OnlineShop2.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "User_index",
                "Admin/{controller}/{action}/{id}",
                new { controller = "User", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
             "User_edit",
             "Admin/{controller}/{action}/{id}",
             new { controller = "User", action = "Edit", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}