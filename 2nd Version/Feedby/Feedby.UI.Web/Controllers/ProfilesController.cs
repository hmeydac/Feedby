namespace Feedby.UI.Web.Controllers
{
    using System.Web.Mvc;

    using Feedby.Profiles.Contracts;

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
            return null;
        }
    }
}
