namespace Feedby.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Feedby.Infrastructure.Domain;
    using Feedby.Infrastructure.Repositories;

    public class ProfileService : IProfileService
    {
        private readonly IProfileDataSource dataSource;

        public ProfileService(IProfileDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public IEnumerable<UserProfile> SearchProfiles(string argument)
        {
            argument = argument.ToLowerInvariant();
            return this.dataSource.GetList(u => u.FirstName.ToLowerInvariant().Contains(argument) || u.LastName.ToLowerInvariant().Contains(argument)).ToList();
        }
    }
}
