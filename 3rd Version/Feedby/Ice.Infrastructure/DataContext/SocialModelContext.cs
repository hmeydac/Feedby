namespace Ice.Infrastructure.DataContext
{
    using System.Data.Entity;

    using Ice.Infrastructure.Entities;

    public class SocialModelContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
