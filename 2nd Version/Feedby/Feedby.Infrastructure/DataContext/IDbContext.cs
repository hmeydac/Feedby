namespace Feedby.Infrastructure.DataContext
{
    using System;
    using System.Data.Entity;

    public interface IDbContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        
        int SaveChanges();
    }
}
