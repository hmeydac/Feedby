namespace Feedby.Infrastructure.Services
{
    using System.Collections.Generic;

    using Feedby.Infrastructure.Domain;

    public interface IProfileService
    {
        IEnumerable<UserProfile> SearchProfiles(string argument);
    }
}
