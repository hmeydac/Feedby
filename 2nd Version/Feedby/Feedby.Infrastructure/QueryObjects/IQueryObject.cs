namespace Feedby.Infrastructure.QueryObjects
{
    using System;

    public interface IQueryObject<T>
    {
        int Skip { get; set; }

        int Take { get; set; }

        Func<T, bool> GetQuery();
    }
}
