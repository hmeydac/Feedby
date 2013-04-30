namespace Feedby.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;

    using Feedby.Infrastructure.Domain;

    public interface IProfileDataSource
    {
        IEnumerable<UserProfile> GetList(Func<UserProfile, bool> predicate);
    }
}
