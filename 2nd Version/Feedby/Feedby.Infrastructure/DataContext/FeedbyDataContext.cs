namespace Feedby.Infrastructure.DataContext
{
    using System.Data.Entity;

    using Feedby.Infrastructure.Domain;

    public class FeedbyDataContext : DbContext
    {
        public FeedbyDataContext()
            : base("Feedby")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<UserBio> UserBios { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.SetProfileAndBioMappings(modelBuilder);
            this.SetReviewMappings(modelBuilder);
            this.SetFeedbackMappings(modelBuilder);
        }

        private void SetProfileAndBioMappings(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                        .HasRequired(u => u.Employee)
                        .WithRequiredPrincipal(e => e.Profile)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<UserBio>()
                        .HasRequired(b => b.Profile)
                        .WithRequiredPrincipal(p => p.Bio)
                        .WillCascadeOnDelete(true);
        }

        private void SetReviewMappings(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasRequired(r => r.To).WithMany(e => e.ReviewsProvided).WillCascadeOnDelete(false);
            modelBuilder.Entity<Review>().HasRequired(r => r.Reviewer).WithMany(e => e.ReviewsReceived).WillCascadeOnDelete(false);
        }

        private void SetFeedbackMappings(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().HasRequired(f => f.From).WithMany(e => e.FeedbacksProvided).WillCascadeOnDelete(false);
            modelBuilder.Entity<Feedback>().HasRequired(f => f.To).WithMany(e => e.FeedbacksReceived).WillCascadeOnDelete(false);
            modelBuilder.Entity<Feedback>().HasOptional(f => f.Review).WithMany(r => r.Feedbacks).HasForeignKey(f => f.ReviewId);
            modelBuilder.Entity<Feedback>().HasMany(f => f.Projects).WithMany(p => p.Feedbacks);
        }
    }
}
