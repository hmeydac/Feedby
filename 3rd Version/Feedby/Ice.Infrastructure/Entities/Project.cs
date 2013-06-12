namespace Ice.Infrastructure.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        public Project()
        {
            this.Feedbacks = new HashSet<Feedback>();
        }

        [Key]
        public Guid ProjectId { get; set; }

        public string Name { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; } 
    }
}