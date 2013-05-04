namespace Feedby.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;

    using Feedby.Infrastructure.QueryObjects;

    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;

        private readonly DbSet<TEntity> entitySet;

        public EntityRepository(DbContext context)
        {
            this.context = context;
            this.entitySet = this.context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.entitySet.AsEnumerable();
        }

        public TEntity Single(IQueryObject<TEntity> query)
        {
            return this.entitySet.SingleOrDefault(query.GetQuery());
        }

        public IEnumerable<TEntity> FindBy(IQueryObject<TEntity> query)
        {
            return this.entitySet.Where(query.GetQuery()).AsEnumerable();
        }

        public TEntity Insert(TEntity entity)
        {
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
    }
}
