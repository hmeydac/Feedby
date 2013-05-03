namespace Feedby.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;

    using Feedby.Infrastructure.Domain;

    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntity<Guid>
    {
        private readonly DbContext context;

        private readonly DbSet<TEntity> entitySet;

        public EntityRepository(IUnitOfWork unitOfWork)
        {
            this.context = unitOfWork.Context;
            this.entitySet = this.context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.entitySet.AsEnumerable();
        }

        public TEntity FindById(Guid id)
        {
            return this.entitySet.FirstOrDefault(e => e.Id.Equals(id));
        }

        public TEntity Insert(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            this.entitySet.Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(TEntity entity)
        {
            this.entitySet.Remove(entity);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
