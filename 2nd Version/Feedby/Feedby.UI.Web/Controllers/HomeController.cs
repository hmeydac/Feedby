namespace Feedby.UI.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult InformalReview()
        {
            return this.View();
        }
    }
}
