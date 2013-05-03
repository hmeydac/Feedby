namespace Feedby.Infrastructure.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Employee : BaseEntity<Guid>
    {
        [MaxLength(50), Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        [Required]
        public UserProfile Profile { get; set; }
    }
}
