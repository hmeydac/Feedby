namespace Feedby.DataContext
{
    using System.Data.Entity;

    using Feedby.Profiles;
    using Feedby.Profiles.Contracts;

    public class FeedbyDataContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
