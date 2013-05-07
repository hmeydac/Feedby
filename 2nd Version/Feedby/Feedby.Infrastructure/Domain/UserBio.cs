namespace Feedby.Infrastructure.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserBio
    {
        [Key]
        public Guid Id { get; set; }

        public UserProfile Profile { get; set; }

        public string BioDescription { get; set; }
    }
}
