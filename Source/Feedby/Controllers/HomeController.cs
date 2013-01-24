using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Feedby.Model;
using Feedby.Models;

namespace Feedby.Controllers
{
    public class HomeController : Controller
    {
        private readonly FeedbyContext context = new FeedbyContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Timeline()
        {
            var reviews = this.GetReviews();
            return this.PartialView(reviews);
        }

        public ActionResult Submit()
        {
            return this.View();
        }

        public JsonResult People(string term, int maxRows)
        {
            if (maxRows <= 0)
            {
                maxRows = 10;
            }

            var people = this.context.Employees.Where(e => e.FirstName.Contains(term) || e.LastName.Contains(term)).Take(maxRows).OrderBy(e => e.FirstName).Select(Mapper.Map<Models.Employee>).ToList();
            return this.Json(people, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SubmittedReviews(int employeeId, DateTime date)
        {
            var reviews = this.GetSubmittedReviews(employeeId, date);
            return this.PartialView("Timeline", reviews);
        }

        private List<Review> GetReviews()
        {
            var feedbacks =
                context.Feedbacks.Include("SubmittedTo").Include("SubmittedBy").Include("FeedbackType").Where(
                    f => f.SubmittedTo.Username == "SW\\hmeydac").OrderByDescending(f => f.SubmittedDate).ToList();

            var feedbackModels = new List<Models.Feedback>();

            feedbacks.ForEach(f => feedbackModels.Add(Mapper.Map<Models.Feedback>(f)));

            var groups = feedbackModels.GroupBy(f => f.WeekYear);
            var reviews = new List<Models.Review>();
            foreach (var group in groups)
            {
                var review = new Review { WeekYear = @group.Key };
                review.Feedbacks.AddRange(@group);
                reviews.Add(review);
            }
            return reviews;
        }

        private List<Review> GetSubmittedReviews(int employeeId, DateTime date)
        {
            var startWeekDay = this.GetStartWeekDay(date);
            var endWeekDay = this.GetEndWeekDay(date);
            var feedbacks =
                context.Feedbacks.Include("SubmittedTo").Include("SubmittedBy").Include("FeedbackType").Where(
                    f => f.SubmittedBy.Username == "SW\\hmeydac" && f.SubmittedTo.Id == employeeId && f.SubmittedDate >= startWeekDay && f.SubmittedDate <= endWeekDay).OrderByDescending(f => f.SubmittedDate).ToList();
           
            var feedbackModels = new List<Models.Feedback>();

            feedbacks.ForEach(f => feedbackModels.Add(Mapper.Map<Models.Feedback>(f)));

            var groups = feedbackModels.GroupBy(f => f.WeekYear);
            var reviews = new List<Models.Review>();
            foreach (var group in groups)
            {
                var review = new Review { WeekYear = @group.Key };
                review.Feedbacks.AddRange(@group);
                reviews.Add(review);
            }
            return reviews;
        }

        private DateTime GetStartWeekDay(DateTime date)
        {
            var days = date.DayOfWeek - System.DayOfWeek.Monday;
            if (days == -1)
            {
                days = 6;
            }

            return date.AddDays(-days);
        }

        private DateTime GetEndWeekDay(DateTime date)
        {
            var days = date.DayOfWeek - System.DayOfWeek.Sunday;
            return date.AddDays(days);
        }
    }
}
