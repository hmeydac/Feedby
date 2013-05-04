namespace Feedby.Infrastructure.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserProfile
    {
        [Key]
        public Guid Id { get; set; }

        public string PictureUrl { get; set; }

        [Required]
        public virtual UserBio Bio { get; set; }
    }
}
