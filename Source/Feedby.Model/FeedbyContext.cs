namespace Feedby.Model
{
    using System.Data.Entity;
    using Entities;

    public class FeedbyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<FeedbackType> FeedbackTypes { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
