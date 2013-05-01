using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedby.UI.Web.Controllers
{
    public class ReviewsController : Controller
    {
        //
        // GET: /Reviews/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Reviews/{userid}

        public ActionResult Details(string userId)
        {
            return View();
        }

    }
}
