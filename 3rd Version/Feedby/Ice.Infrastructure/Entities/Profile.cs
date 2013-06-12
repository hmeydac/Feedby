namespace Ice.Infrastructure.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Profile
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public User User { get; set; }

        public string Bio { get; set; }

        public string AvatarUrl { get; set; }
    }
}