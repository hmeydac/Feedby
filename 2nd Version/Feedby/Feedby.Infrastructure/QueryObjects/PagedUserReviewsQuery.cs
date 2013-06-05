namespace Feedby.Infrastructure.QueryObjects
{
    using System;

    using Feedby.Infrastructure.Domain;

    public class PagedUserReviewsQuery : QueryObject<Review>
    {
        public PagedUserReviewsQuery(string username, int skip, int take)
            : base(false)
        {
            this.Username = username;
            this.Skip = skip;
            this.Take = take;
        }

        public string Username { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }

        public override Func<Review, bool> GetQuery()
        {
            return (r) => QueryExpressions.UserReviews(r, this.Username);
        }
    }
}
