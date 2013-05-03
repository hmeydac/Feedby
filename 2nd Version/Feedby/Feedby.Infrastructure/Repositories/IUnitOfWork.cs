namespace Feedby.Infrastructure.Repositories
{
    using System;
    using System.Data.Entity;

    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; set; }

        void Commit();
    }
}