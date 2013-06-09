namespace Feedby.UI.Web.Models.Feedbacks
{
    using System;
    using System.Collections.Generic;

    public class GroupedFeedbacksKeyModel
    {
        public GroupedFeedbacksKeyModel()
        {
            this.Projects = new List<string>();
        }

        public string Week { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string Year { get; set; }

        public IList<string> Projects { get; set; }

        public override bool Equals(object obj)
        {
            var obj2 = obj as GroupedFeedbacksKeyModel;
            if (obj2 != null)
            {
                if (ReferenceEquals(obj2, this))
                {
                    return true;
                }

                if (string.IsNullOrEmpty(obj2.Week) && string.IsNullOrEmpty(this.Week))
                {
                    return true;
                }

                return obj2.Week.Equals(this.Week);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (this.Week != null ? this.Week.GetHashCode() : 0);
        }
    }
}