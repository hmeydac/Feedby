namespace Feedby.Infrastructure.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserBio : BaseEntity<Guid>
    {
        [Key, ForeignKey("UserProfile")]
        public new Guid Id { get; set; }

        [ForeignKey("Id")]
        public virtual UserProfile UserProfile { get; set; }

        public string BioDescription { get; set; }
    }
}
