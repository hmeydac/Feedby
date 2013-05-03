namespace Feedby.Infrastructure.DataContext
{
    using System.Data.Entity;

    public class FeedbyDataContext : DbContext
    {
        public FeedbyDataContext()
            : base("Feedby")
        {
        }
    }
}
