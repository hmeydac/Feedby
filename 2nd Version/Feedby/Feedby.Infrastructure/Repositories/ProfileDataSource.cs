namespace Feedby.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Feedby.Infrastructure.DataContext;
    using Feedby.Infrastructure.Domain;

    public class ProfileDataSource : IProfileDataSource
    {
        private readonly FeedbyDataContext context = new FeedbyDataContext();
            
        public IEnumerable<UserProfile> GetList(Func<UserProfile, bool> predicate)
        {
            return this.context.UserProfiles.Where(predicate);  
        }
    }
}
