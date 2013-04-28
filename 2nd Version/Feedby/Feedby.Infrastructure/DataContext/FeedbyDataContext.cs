namespace Feedby.Infrastructure.DataContext
{
    using System.Data.Entity;

    using Feedby.Infrastructure.Domain;

    public class FeedbyDataContext : DbContext
    {
        public FeedbyDataContext() : base("Feedby")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
