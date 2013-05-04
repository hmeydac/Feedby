namespace Feedby.Infrastructure.QueryObjects
{
    using System;

    public interface IQueryObject<T>
    {
        Func<T, bool> GetQuery();
    }
}
