namespace Feedby.Infrastructure.QueryObjects
{
    using System;
    using System.Linq.Expressions;

    public abstract class QueryObject<TEntity> : IQueryObject<TEntity>
    {
        protected QueryObject(bool useCompiled)
        {
            this.UseCompiled = useCompiled;
        }

        protected bool UseCompiled
        {
            get;
            private set;
        }

        public abstract Func<TEntity, bool> GetQuery();
    }
}
