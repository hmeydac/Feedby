namespace Feedby.UI.Web.Models.Feedbacks
{
    using System.Collections.Generic;
    using System.Linq;

    public class GroupedFeedbacksModel
    {
        public GroupedFeedbacksKeyModel Key { get; set; }

        public IEnumerable<IGrouping<string, FeedbackModel>> FeedbacksByReviewer { get; set; } 
    }
}