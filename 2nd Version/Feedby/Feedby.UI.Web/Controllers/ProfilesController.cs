namespace Feedby.UI.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;

    using Feedby.Infrastructure.Services;
    using Feedby.UI.Web.Models;

    using WebGrease.Css.Extensions;

    public class ProfilesController : Controller
    {
        private readonly IEmployeeService employeeService;

        public ProfilesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Search(string argument)
        {
            var employees = this.employeeService.FilterByName(argument);
            var viewModel = new List<UserProfileModel>();

            employees.ForEach(e => viewModel.Add(Mapper.Map<UserProfileModel>(e)));

            return this.PartialView("ProfileSearchResults", viewModel);
        }
    }
}
