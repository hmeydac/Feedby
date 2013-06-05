namespace Feedby.Infrastructure.QueryObjects
{
    using System;

    public abstract class QueryObject<TEntity> : IQueryObject<TEntity>
    {
        protected QueryObject(bool useCompiled)
        {
            this.UseCompiled = useCompiled;
        }

        public int Skip { get; set; }

        public int Take { get; set; }

        protected bool UseCompiled
        {
            get;
            private set;
        }

        public abstract Func<TEntity, bool> GetQuery();
    }
}
