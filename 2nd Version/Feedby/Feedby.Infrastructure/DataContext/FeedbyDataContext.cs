namespace Feedby.Infrastructure.DataContext
{
    using System.Data.Entity;

    using Feedby.Infrastructure.Domain;

    public class FeedbyDataContext : DbContext, IDbContext
    {
        public FeedbyDataContext()
            : base("Feedby")
        {
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
