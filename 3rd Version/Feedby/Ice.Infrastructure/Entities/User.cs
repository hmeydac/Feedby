namespace Ice.Infrastructure.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public User()
        {
            this.Reviews = new HashSet<Review>();
            this.ProvidedFeedbacks = new HashSet<Feedback>();
            this.GivenFeedbacks = new HashSet<Feedback>();
        }

        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [Required]
        public virtual Profile Profile { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Feedback> ProvidedFeedbacks { get; set; }

        public virtual ICollection<Feedback> GivenFeedbacks { get; set; }
    }
}
