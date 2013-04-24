namespace Feedby.Profiles.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Feedby.DataContext;
    using Feedby.Profiles.Contracts;

    public class ProfileDataSource : IProfileDataSource
    {
        private FeedbyDataContext context = new FeedbyDataContext();
            
        public IEnumerable<UserProfile> GetList(Func<UserProfile, bool> predicate)
        {
            return this.context.UserProfiles.Where(predicate);  
        }
    }
}
