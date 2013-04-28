namespace Feedby.UI.Web.Controllers
{
    using System.Web.Mvc;

    using Feedby.Infrastructure.Domain;
    using Feedby.Infrastructure.Services;

    using System.Collections.Generic;

    using Feedby.UI.Web.Models;

    public class ProfilesController : Controller
    {
        private IProfileService profileService;

        public ProfilesController(IProfileService service)
        {
            this.profileService = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string argument)
        {
            // var profiles = this.profileService.SearchProfiles(argument);

            var userProfiles = new List<UserProfileModel>
            {
                new UserProfileModel { FirstName = "Marcos", LastName = "Castany" },
                new UserProfileModel { FirstName = "Juan", LastName = "Arguello" },
                new UserProfileModel { FirstName = "Jorge", LastName = "Rowies" },
                new UserProfileModel { FirstName = "Hernan", LastName = "Meydac Jean"},
            };
            return this.PartialView("ProfileSearchResults", userProfiles);
        }
    }
}
