namespace Ice.Infrastructure.DataContext
{
    using System.Data.Entity;

    using Ice.Infrastructure.Entities;

    public class IceContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasMany(c => c.Feedbacks)
                .WithMany(c => c.Reviews)
                .Map(m =>
                    {
                        m.MapLeftKey("ReviewId");
                        m.MapRightKey("FeedbackId");
                        m.ToTable("ReviewFeedbacks");
                    });

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Feedbacks)
                .WithMany(p => p.Projects)
                .Map(m =>
                    {
                        m.MapLeftKey("ProjectId");
                        m.MapRightKey("FeedbackId");
                        m.ToTable("ProjectFeedbacks");
                    });

            modelBuilder.Entity<User>()
                        .HasRequired(u => u.Profile)
                        .WithRequiredPrincipal(p => p.User)
                        .WillCascadeOnDelete(false);
        }
    }
}
