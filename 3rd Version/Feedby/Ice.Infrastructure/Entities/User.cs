namespace Ice.Infrastructure.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(30)]
        [Required]
        public string Username { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
    }
}
