namespace Feedby.UI.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Feedby.Infrastructure.Domain;
    using Feedby.Infrastructure.Services;
    using Feedby.UI.Web.Models;
    using Feedby.UI.Web.Models.Feedbacks;
    using Feedby.UI.Web.Utils;

    using WebGrease.Css.Extensions;

    public class ProfilesController : Controller
    {
        private readonly IEmployeeService employeeService;

        private readonly IReviewService reviewService;

        public ProfilesController(IEmployeeService employeeService, IReviewService reviewService)
        {
            this.employeeService = employeeService;
            this.reviewService = reviewService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Details(string username)
        {
            var employee = this.employeeService.SingleByUsername(username);
            return this.View(Mapper.Map<UserProfileModel>(employee));
        }

        [HttpPost]
        public ActionResult Search(string argument)
        {
            var employees = this.employeeService.FilterByName(argument);
            var viewModel = new List<UserProfileModel>();

            employees.ForEach(e => viewModel.Add(Mapper.Map<UserProfileModel>(e)));

            return this.PartialView("ProfileSearchResults", viewModel);
        }

        public ActionResult RecentActivity()
        {
            var review = this.reviewService.GetLastReviews("pepe", 0, 5);
            var viewModel = this.GetRecentActivity();
            return this.PartialView("RecentFeedbackActivity", viewModel);
        }

        private List<GroupedFeedbacksModel> GetRecentActivity()
        {
            var feedbacks = this.GetFakeData();

            var grouped =
                feedbacks.GroupBy(f => new GroupedFeedbacksKeyModel
                {
                    Week = f.Week.Substring(5, 2),
                    Year = f.Week.Substring(0, 4),
                    From = DateUtils.GetWeekFromDate(f.Week),
                    To = DateUtils.GetToDate(f.Week)
                })
                         .OrderByDescending(f => f.Key.Week)
                         .Select(f => new GroupedFeedbacksModel { Key = f.Key, FeedbacksByReviewer = f.GroupBy(f2 => f2.FromFullName).OrderBy(f2 => f2.Key) })
                         .ToList();

            foreach (var group in grouped)
            {
                var projectsTmp = group.FeedbacksByReviewer.Select(x => x.SelectMany(y => y.Projects).Distinct());
                foreach (var p in projectsTmp.SelectMany(item => item))
                {
                    if (!group.Key.Projects.Contains(p))
                    {
                        group.Key.Projects.Add(p);
                    }
                }
            }

            return grouped;
        }

        private IEnumerable<FeedbackModel> GetFakeData()
        {
            var feedbacks = new List<FeedbackModel>
                                {
                                    new FeedbackModel
                                        {
                                            FeedbackType = FeedbackType.Positive,
                                            FromFullName = "Marcos Castany",
                                            Projects =
                                                new List<string>
                                                    {
                                                        "project1",
                                                        "project2"
                                                    },
                                            Text =
                                                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam suscipit arcu non metus euismod hendrerit vitae id dui. Curabitur feugiat, libero non rhoncus congue, eros ipsum sagittis massa, non sagittis sapien nunc ut est. Fusce fermentum ultricies arcu in venenatis. Aliquam erat volutpat.",
                                            ToFullName = "Marcos Castany",
                                            Week = "2013w20"
                                        },
                                    new FeedbackModel
                                        {
                                            FeedbackType = FeedbackType.Improve,
                                            FromFullName = "Jorge Rowies",
                                            Projects =
                                                new List<string>
                                                    {
                                                        "project1",
                                                        "project2"
                                                    },
                                            Text =
                                                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam suscipit arcu non metus euismod hendrerit vitae id dui. Curabitur feugiat, libero non rhoncus congue, eros ipsum sagittis massa, non sagittis sapien nunc ut est. Fusce fermentum ultricies arcu in venenatis. Aliquam erat volutpat.",
                                            ToFullName = "Marcos Castany",
                                            Week = "2013w20"
                                        },
                                    new FeedbackModel
                                        {
                                            FeedbackType = FeedbackType.Negative,
                                            FromFullName = "Jorge Rowies",
                                            Projects =
                                                new List<string>
                                                    {
                                                        "project1",
                                                        "project2"
                                                    },
                                            Text =
                                                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam suscipit arcu non metus euismod hendrerit vitae id dui. Curabitur feugiat, libero non rhoncus congue, eros ipsum sagittis massa, non sagittis sapien nunc ut est. Fusce fermentum ultricies arcu in venenatis. Aliquam erat volutpat.",
                                            ToFullName = "Marcos Castany",
                                            Week = "2013w21"
                                        }
                                };

            return feedbacks;
        }
    }
}
