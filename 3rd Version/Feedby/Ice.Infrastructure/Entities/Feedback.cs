namespace Ice.Infrastructure.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Feedback
    {
        public Feedback()
        {
            this.Projects = new HashSet<Project>();
        }

        [Key]
        public Guid FeedbackId { get; set; }

        public virtual User From { get; set; }

        public virtual User To { get; set; }

        public string Text { get; set; }

        public int Week { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}