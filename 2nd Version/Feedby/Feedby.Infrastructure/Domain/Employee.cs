namespace Feedby.Infrastructure.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50), Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        [MaxLength(100), Required]
        public string Email { get; set; }

        [MaxLength(32), Required]
        public string Username { get; set; }

        [Required]
        public UserProfile Profile { get; set; }

        public IList<Review> ReviewsReceived { get; set; }

        public IList<Review> ReviewsProvided { get; set; }

        public IList<Feedback> FeedbacksReceived { get; set; }

        public IList<Feedback> FeedbacksProvided { get; set; }
    }
}
