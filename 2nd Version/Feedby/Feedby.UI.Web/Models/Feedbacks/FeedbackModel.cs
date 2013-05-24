namespace Feedby.UI.Web.Models.Feedbacks
{
    using System;
    using System.Collections.Generic;

    using Feedby.Infrastructure.Domain;

    public class FeedbackModel
    {
        public Guid Id { get; set; }

        public string Week { get; set; }

        public Guid? ReviewId { get; set; }

        public FeedbackType FeedbackType { get; set; }

        public string Text { get; set; }

        public string FromFullName { get; set; }

        public string ToFullName { get; set; }

        public IList<string> Projects { get; set; }
    }
}