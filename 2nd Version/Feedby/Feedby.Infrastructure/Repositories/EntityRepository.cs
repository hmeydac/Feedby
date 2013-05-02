namespace Feedby.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Feedby.Infrastructure.DataContext;

    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        private IDbContext context;

        public EntityRepository(IDbContext context)
        {
            this.context = context;
        }

        private IDbSet<TEntity> Entities
        {
            get { return this.context.Set<TEntity>(); }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.Entities.AsEnumerable();
        }

        public TEntity GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public TEntity Insert(TEntity entity)
        {
            this.Entities.Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.context.SaveChanges();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            this.Entities.Remove(entity);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || this.context == null)
            {
                return;
            }

            this.context.Dispose();
            this.context = null;
        }
    }
}
