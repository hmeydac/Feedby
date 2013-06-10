namespace Ice.Infrastructure.Tests
{
    using System;
    using System.Linq;
    using System.Transactions;

    using Ice.Infrastructure.Entities;
    using Ice.Infrastructure.Services;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Ninject;

    [TestClass]
    public class UserDirectoryTest : InjectionUnitTest
    {
        private TransactionScope transaction;

        [TestInitialize]
        public void StartScope()
        {
            this.transaction = new TransactionScope();
        }

        [TestMethod]
        public void QueryFullUserDirectory()
        {
            // Arrange
            var directory = this.Kernel.Get<UserDirectory>();

            // Act
            var users = directory.GetUsers();

            // Assert
            Assert.IsNotNull(users);
            Assert.IsInstanceOfType(users, typeof(User[]));
        }

        [TestMethod]
        public void AddUserToDirectory()
        {
            // Arrange
            var expectedUser = GetTestUser();
            var directory = this.Kernel.Get<UserDirectory>();

            // Act
            directory.AddUser(expectedUser);
            directory.CommitChanges();
            var actualUser = directory.GetUser(expectedUser.Id);

            // Assert
            Assert.IsNotNull(actualUser);
            Assert.IsInstanceOfType(actualUser, typeof(User));
            Assert.AreSame(expectedUser, actualUser);
        }

        [TestMethod]
        public void RemoveUserFromDirectory()
        {
            // Arrange
            this.AddUserToDirectory();
            var directory = this.Kernel.Get<UserDirectory>();
            var currentCount = directory.GetUsers().Count();
            const int ExpectedCount = 0;
            var userToDelete = directory.GetUsers().FirstOrDefault();
            
            // Act
            directory.RemoveUser(userToDelete.Id);
            directory.CommitChanges();
            var actualCount = directory.GetUsers().Count();
            var actual = directory.GetUser(userToDelete.Id);
            
            // Assert
            Assert.AreNotEqual(currentCount, actualCount);
            Assert.AreEqual(ExpectedCount, actualCount);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void UpdateUserFromDirectory()
        {
            // Arrange
            this.AddUserToDirectory();
            var directory = this.Kernel.Get<UserDirectory>();
            var userToUpdate = directory.GetUsers().FirstOrDefault();
            var currentName = userToUpdate.FirstName;
            const string ExpectedName = "Updated Name";

            // Act
            userToUpdate.FirstName = ExpectedName;
            directory.CommitChanges();
            var actual = directory.GetUser(userToUpdate.Id);

            // Assert
            Assert.AreEqual(ExpectedName, actual.FirstName);
            Assert.AreNotEqual(currentName, actual.FirstName);
        }

        [TestMethod]
        public void GetPagedUsersFromDirectory()
        {
            // Arrange
            for (var i = 0; i < 12; i++)
            {
                this.AddUserToDirectory();
            }

            var directory = this.Kernel.Get<UserDirectory>();
            const int PageNumber = 1;
            const int ResultsPerPage = 10;
            const int ExpectedFirstPageResults = 10;
            const int ExpectedSecondPageResults = 2;

            // Act
            var firstPageUsers = directory.GetUsers(PageNumber, ResultsPerPage);
            var secondPageUsers = directory.GetUsers(PageNumber + 1, ResultsPerPage);
            
            // Assert
            Assert.AreEqual(ExpectedFirstPageResults, firstPageUsers.Count());
            Assert.AreEqual(ExpectedSecondPageResults, secondPageUsers.Count());
            CollectionAssert.AllItemsAreUnique(firstPageUsers);
            CollectionAssert.AllItemsAreUnique(secondPageUsers);
            CollectionAssert.AreNotEquivalent(firstPageUsers, secondPageUsers);
        }

        [TestCleanup]
        public void CleanupScope()
        {
            this.transaction.Dispose();
        }

        private static User GetTestUser()
        {
            var expectedUser = new User
                                   {
                                       FirstName = "Test Firstname",
                                       LastName = "Test Lastname",
                                       Username = "testuser",
                                       Email = "test@email.com",
                                       Id = Guid.NewGuid()
                                   };
            return expectedUser;
        }
    }
}
