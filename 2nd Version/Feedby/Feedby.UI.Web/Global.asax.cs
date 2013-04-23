namespace Feedby.UI.Web
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Feedby.UI.Web.Models;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            this.SetDefaultProfile();
        }

        private void SetDefaultProfile()
        {
            var userProfile = new UserProfileModel { FirstName = "Juan", LastName = "Arguello", Username = "jarguello", ProfileImageUrl = "~/Content/jarguello.jpg" };
            Session.Add(DomainConstants.UserProfile, userProfile);
        }
    }
}