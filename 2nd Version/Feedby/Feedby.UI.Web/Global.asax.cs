namespace Feedby.UI.Web
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using AutoMapper;

    using Feedby.Infrastructure.Domain;
    using Feedby.UI.Web.Models;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            this.ConfigureMappings();
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

        private void ConfigureMappings()
        {
            Mapper.CreateMap<Employee, UserProfileModel>()
                    .ForMember(e => e.Id, o => o.MapFrom(e => e.Id))
                    .ForMember(e => e.FirstName, o => o.MapFrom(e => e.FirstName))
                    .ForMember(e => e.LastName, o => o.MapFrom(e => e.LastName))
                    .ForMember(e => e.ProfileImageUrl, o => o.MapFrom(e => e.Profile.PictureUrl));
        }
    }
}