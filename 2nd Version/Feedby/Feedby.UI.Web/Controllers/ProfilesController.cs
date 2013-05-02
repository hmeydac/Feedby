namespace Feedby.UI.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Feedby.UI.Web.Models;

    public class ProfilesController : Controller
    {

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Search(string argument)
        {
            var userProfiles = new List<UserProfileModel>
            {
                new UserProfileModel { FirstName = "Marcos", LastName = "Castany" },
                new UserProfileModel { FirstName = "Juan", LastName = "Arguello" },
                new UserProfileModel { FirstName = "Jorge", LastName = "Rowies" },
                new UserProfileModel { FirstName = "Hernan", LastName = "Meydac Jean"}
            };

            return this.PartialView("ProfileSearchResults", userProfiles);
        }
    }
}
