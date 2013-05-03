namespace Feedby.Infrastructure.Repositories
{
    using System.Data.Entity;

    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext context)
        {
            this.Context = context;
        }

        public DbContext Context { get; set; }

        public void Commit()
        {
            this.Context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
    }
}
