namespace Feedby.Infrastructure.Services
{
    using System;

    public interface IEntityService<TEntity>
    {
        void Delete(TEntity entity);

        TEntity Save(TEntity entity);

        TEntity GetById(Guid id);
    }
}
