namespace Feedby.Infrastructure.Repositories
{
    using System.Collections.Generic;

    using Feedby.Infrastructure.QueryObjects;

    public interface IEntityRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity Single(IQueryObject<TEntity> query, params string[] includes);

        IEnumerable<TEntity> FindBy(IQueryObject<TEntity> query, params string[] includes);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
