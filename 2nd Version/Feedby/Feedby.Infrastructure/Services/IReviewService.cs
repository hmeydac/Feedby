namespace Feedby.Infrastructure.Services
{
    using System.Collections.Generic;

    using Feedby.Infrastructure.Domain;

    public interface IReviewService : IEntityService<Review>
    {
        IEnumerable<Review> GetLastReviews(string username, int skip, int occurrences);
    }
}