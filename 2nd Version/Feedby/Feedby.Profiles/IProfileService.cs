namespace Feedby.Profiles.Contracts
{
    using System.Collections.Generic;

    public interface IProfileService
    {
        IEnumerable<UserProfile> SearchProfiles(string argument);
    }
}
