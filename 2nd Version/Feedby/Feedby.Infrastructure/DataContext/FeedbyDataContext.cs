namespace Feedby.Infrastructure.DataContext
{
    using System.Data.Entity;

    using Feedby.Infrastructure.Domain;

    public class FeedbyDataContext : DbContext
    {
        public FeedbyDataContext()
            : base("Feedby")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<UserBio> UserBios { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

    }
}
