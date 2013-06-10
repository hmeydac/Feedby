namespace Ice.Infrastructure.Services
{
    using System.Data.Entity;

    using Ice.Infrastructure.Entities;

    public interface IEntityRepository
    {
        DbContext Context { get; set; }

        DbSet<User> DataSet { get; set; }

        bool CommitChanges();
    }
}