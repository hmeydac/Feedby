namespace Feedby.UI.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Profiles Routes
            routes.MapRoute("SearchProfiles", "Profiles/Search", new { controller = "Profiles", action = "Search" });
            routes.MapRoute("RecentActivity", "Profiles/RecentActivity", new { controller = "Profiles", action = "RecentActivity" });
            routes.MapRoute("Profile", "Profiles/{username}", new { controller = "Profiles", action = "Details" });

            // Default Route
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}