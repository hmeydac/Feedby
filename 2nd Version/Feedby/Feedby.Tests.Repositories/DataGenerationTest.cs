namespace Feedby.Tests.Repositories
{
    using System;

    using Feedby.Infrastructure.DataContext;
    using Feedby.Infrastructure.Domain;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataGenerationTest
    {
        private const string PictureUrl = "~/content/images/jarguello.jpg";

        private readonly string[] firstNames = { "Jorge", "Marcos", "Hernan", "Martin", "Damian", "Juan" };

        private readonly string[] lastNames = { "Rowies", "Castany", "Meydac", "Cabral", "Yenkel", "Arguello" };

        [TestMethod]
        public void GenerateProfileData()
        {
            var context = new FeedbyDataContext();

            // Clear existing data
            foreach (var existingProfile in context.UserProfiles)
            {
                context.UserProfiles.Remove(existingProfile);
            }

            // Create sample profiles & bio
            for (var i = 0; i < 5; i++)
            {
                var bio = this.CreateUserBio(string.Format("Sample Bio {0}", i));
                var profile = this.CreateProfile(bio);
                context.UserProfiles.Add(profile);
            }

            // Persist changes
            context.SaveChanges();
        }

        private UserProfile CreateProfile(UserBio bio)
        {
            var rand = new Random((int)DateTime.Now.Ticks);
            return new UserProfile
                       {
                           FirstName = this.firstNames[rand.Next(0, this.firstNames.Length - 1)],
                           LastName = this.lastNames[rand.Next(0, this.lastNames.Length - 1)],
                           Id = Guid.NewGuid(),
                           PictureUrl = PictureUrl,
                           Bio = bio
                       };
        }

        private UserBio CreateUserBio(string description)
        {
            return new UserBio { BioDescription = description, Id = Guid.NewGuid() };
        }
    }
}
