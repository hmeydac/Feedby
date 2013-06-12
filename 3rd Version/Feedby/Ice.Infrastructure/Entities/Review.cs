namespace Ice.Infrastructure.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        public Review()
        {
            this.Feedbacks = new HashSet<Feedback>();
        }

        [Key]
        public Guid ReviewId { get; set; }

        public int Week { get; set; }

        public int Year { get; set; }

        public virtual User From { get; set; }

        public virtual User To { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}