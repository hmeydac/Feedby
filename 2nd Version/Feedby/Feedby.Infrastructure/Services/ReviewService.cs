namespace Feedby.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;

    using Feedby.Infrastructure.Domain;
    using Feedby.Infrastructure.QueryObjects;
    using Feedby.Infrastructure.Repositories;

    public class ReviewService : IReviewService
    {
        private readonly IEntityRepository<Review> reviewRepository;

        public ReviewService(IEntityRepository<Review> reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public void Delete(Review entity)
        {
            throw new NotImplementedException();
        }

        public Review Save(Review entity)
        {
            throw new NotImplementedException();
        }

        public Review SingleById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Review> GetLastReviews(string username, int skip, int occurrences)
        {
            var query = new PagedUserReviewsQuery(username, skip, occurrences) { Skip = skip, Take = occurrences };
            return this.reviewRepository.FindBy(query);
        }
    }
}
