namespace Feedby.Infrastructure.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserProfile : BaseEntity<Guid>
    {
        public string PictureUrl { get; set; }

        [Required]
        public virtual UserBio Bio { get; set; }
    }
}
