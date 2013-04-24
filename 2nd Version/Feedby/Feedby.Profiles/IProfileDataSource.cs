namespace Feedby.Profiles.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IProfileDataSource
    {
        IEnumerable<UserProfile> GetList(Func<UserProfile, bool> predicate);
    }
}
