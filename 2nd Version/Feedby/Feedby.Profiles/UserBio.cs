namespace Feedby.Profiles.Contracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserBio
    {
        [Key, ForeignKey("UserProfile")]
        public Guid Id { get; set; }

        [ForeignKey("UserProfileId")]
        public virtual UserProfile UserProfile { get; set; }

        public string BioDescription { get; set; }
    }
}
