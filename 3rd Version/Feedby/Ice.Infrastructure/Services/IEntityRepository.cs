namespace Ice.Infrastructure.Services
{
    using System.Data.Entity;

    public interface IEntityRepository<T> where T : class
    {
        DbContext Context { get; set; }

        DbSet<T> DataSet { get; set; }

        bool CommitChanges();
    }
}