namespace Feedby.UI.Web.Controllers
{
    using System.Web.Mvc;

    using Feedby.Profiles.Contracts;
    using System.Collections.Generic;

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
            var profiles = this.profileService.SearchProfiles(argument);

            IList<UserProfile> profilesHC = new List<UserProfile>
            {
                new UserProfile { FirstName = "Marcos", LastName = "Castany" },
                new UserProfile { FirstName = "Juan", LastName = "Arguello" },
                new UserProfile { FirstName = "Jorge", LastName = "Rowies" },
                new UserProfile { FirstName = "Hernan", LastName = "Meydac Jean"},
            };
            return this.PartialView("ProfileSearchResults", profilesHC);
        }
    }
}
