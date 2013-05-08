namespace Feedby.Infrastructure.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Feedback
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Week { get; set; }

        public Guid? ReviewId { get; set; }

        public Review Review { get; set; }

        [Required]
        public FeedbackType FeedbackType { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Employee From { get; set; }
        
        [Required]
        public Employee To { get; set; }

        public Project Project { get; set; }

        public Guid? ProjectId { get; set; }
    }
}