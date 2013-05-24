namespace Feedby.UI.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    using Feedby.Infrastructure.Domain;
    using Feedby.UI.Web.Models;
    using Feedby.UI.Web.Models.Feedbacks;
    using Feedby.UI.Web.Utils;

    public class FeedbacksController : Controller
    {
        public ActionResult Recent(string userId)
        {
            var feedbacks = GetFakeData();

            var grouped =
                feedbacks.GroupBy(f => new GroupedFeedbacksKeyModel
                                           {
                                               Week = f.Week.Substring(5, 2),
                                               Year = f.Week.Substring(0, 4),
                                               From = DateUtils.GetWeekFromDate(f.Week),
                                               To = DateUtils.GetToDate(f.Week)
                                           })
                         .OrderBy(f => f.Key.Week)
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

            return this.View(grouped);
        }

        private static List<FeedbackModel> GetFakeData()
        {
            var feedbacks = new List<FeedbackModel>();

            feedbacks.Add(
                new FeedbackModel
                    {
                        FeedbackType = FeedbackType.Positive,
                        FromFullName = "Marcos Castany",
                        Projects = new List<string> { "project1", "project2" },
                        Text =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam suscipit arcu non metus euismod hendrerit vitae id dui. Curabitur feugiat, libero non rhoncus congue, eros ipsum sagittis massa, non sagittis sapien nunc ut est. Fusce fermentum ultricies arcu in venenatis. Aliquam erat volutpat.",
                        ToFullName = "Marcos Castany",
                        Week = "2013w20"
                    });

            feedbacks.Add(
                new FeedbackModel
                    {
                        FeedbackType = FeedbackType.Improve,
                        FromFullName = "Jorge Rowies",
                        Projects = new List<string> { "project1", "project2" },
                        Text =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam suscipit arcu non metus euismod hendrerit vitae id dui. Curabitur feugiat, libero non rhoncus congue, eros ipsum sagittis massa, non sagittis sapien nunc ut est. Fusce fermentum ultricies arcu in venenatis. Aliquam erat volutpat.",
                        ToFullName = "Marcos Castany",
                        Week = "2013w20"
                    });

            feedbacks.Add(
                new FeedbackModel
                    {
                        FeedbackType = FeedbackType.Negative,
                        FromFullName = "Jorge Rowies",
                        Projects = new List<string> { "project1", "project2" },
                        Text =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam suscipit arcu non metus euismod hendrerit vitae id dui. Curabitur feugiat, libero non rhoncus congue, eros ipsum sagittis massa, non sagittis sapien nunc ut est. Fusce fermentum ultricies arcu in venenatis. Aliquam erat volutpat.",
                        ToFullName = "Marcos Castany",
                        Week = "2013w21"
                    });

            return feedbacks;
        }
    }
}
