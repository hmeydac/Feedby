namespace Feedby.Infrastructure.Repositories
{
    using System.Collections.Generic;

    public interface IEntityRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(object id);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
