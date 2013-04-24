namespace Feedby.Profiles.Contracts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserProfile
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PictureUrl { get; set; }

        public virtual UserBio Bio { get; set; }
    }
}
