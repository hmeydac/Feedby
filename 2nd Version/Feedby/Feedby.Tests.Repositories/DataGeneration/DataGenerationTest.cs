namespace Feedby.Tests.Repositories.DataGeneration
{
    using System;

    using Feedby.Infrastructure.DataContext;
    using Feedby.Infrastructure.Domain;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DataGenerationTest
    {
        private readonly string[] pictureUrls = { "/content/images/jarguello.jpg", "/content/images/ajerz.jpg", "/content/images/jrowies.png", "/content/images/mconverti.jpg", "/content/images/dmartinez.jpg" };

        private readonly string[] firstNames = { "Jorge", "Marcos", "Hernan", "Martin", "Damian", "Juan" };

        private readonly string[] lastNames = { "Rowies", "Castany", "Meydac", "Cabral", "Yenkel", "Arguello" };

        [TestMethod]
        public void GenerateEmployeeData()
        {
            var context = new FeedbyDataContext();

            // Clear existing data
            this.ClearData(context);
            for (var i = 0; i < 5; i++)
            {
                var rand = new Random((int)DateTime.Now.Ticks);
                var bio = this.CreateUserBio(string.Format("Sample Bio {0}", i));
                var profile = this.CreateProfile(bio);
                profile.PictureUrl = this.pictureUrls[i];
                var employee = new Employee
                                   {
                                       Id = Guid.NewGuid(),
                                       FirstName = this.firstNames[rand.Next(0, this.firstNames.Length - 1)],
                                       LastName = this.lastNames[rand.Next(0, this.lastNames.Length - 1)],
                                       Profile = profile
                                   };

                employee.Username = string.Format("{0}{1}", employee.FirstName[0], employee.LastName);
                employee.Email = string.Format("{0}@{1}.net", employee.FirstName, employee.LastName);
                context.Set<Employee>().Add(employee);
            }

            context.SaveChanges();
        }

        private void ClearData(FeedbyDataContext context)
        {
            // Clear existing data
            foreach (var employee in context.Set<Employee>())
            {
                context.Set<Employee>().Remove(employee);
            }
        }

        private UserProfile CreateProfile(UserBio bio)
        {
            return new UserProfile
                       {
                           Id = Guid.NewGuid(),
                           Bio = bio
                       };
        }

        private UserBio CreateUserBio(string description)
        {
            return new UserBio { BioDescription = description, Id = Guid.NewGuid() };
        }
    }
}
