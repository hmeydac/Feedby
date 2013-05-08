namespace Feedby.Infrastructure.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Week { get; set; }

        public IList<Feedback> Feedbacks { get; set; }

        [Required]
        public Employee Reviewer { get; set; }

        [Required]
        public Employee To { get; set; }
    }
}
