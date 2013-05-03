namespace Feedby.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;

    using Feedby.Infrastructure.Domain;

    public interface IEntityRepository<TEntity> where TEntity : BaseEntity<Guid>
    {
        IEnumerable<TEntity> GetAll();

        TEntity FindById(Guid id);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        void SaveChanges();
    }
}
