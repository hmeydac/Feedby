namespace Feedby.Infrastructure.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<Feedback> Feedbacks { get; set; } 
    }
}
