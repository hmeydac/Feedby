namespace Feedby.Tests.Repositories.Repositories
{
    using System;
    using System.Transactions;

    using Feedby.Infrastructure.DataContext;
    using Feedby.Infrastructure.Domain;
    using Feedby.Infrastructure.QueryObjects;
    using Feedby.Infrastructure.Repositories;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EmployeeRepositoryFixture
    {
        private TransactionScope transaction;

        private FeedbyDataContext context;

        [TestInitialize]
        public void Startup()
        {
            this.transaction = new TransactionScope();
            this.context = new FeedbyDataContext();
        }

        [TestMethod]
        public void WhenInsertingEmployeeShouldSaveIt()
        {
            // Arrange
            const string ExpectedFirstName = "FirstName";
            const string ExpectedLastName = "LastName";
            var expectedId = Guid.NewGuid();

            var employeeRepository = new EntityRepository<Employee>(this.context);
            var employee = CreateEmployee(expectedId, ExpectedFirstName, ExpectedLastName);
            var query = new EmployeeIdQuery(expectedId);

            // Act
            employeeRepository.Insert(employee);
            this.context.SaveChanges();
            var actual = employeeRepository.Single(query);

            // Assert
            Assert.AreEqual(expectedId, actual.Id);
            Assert.AreEqual(ExpectedFirstName, actual.FirstName);
            Assert.AreEqual(ExpectedLastName, actual.LastName);
        }

        private static Employee CreateEmployee(Guid id, string firstName, string lastName)
        {
            var bio = new UserBio { Id = Guid.NewGuid(), BioDescription = "Test" };
            var profile = new UserProfile { Id = Guid.NewGuid(), Bio = bio };
            var employee = new Employee
                               {
                                   Id = id,
                                   FirstName = firstName,
                                   LastName = lastName,
                                   Profile = profile
                               };
            return employee;
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (this.transaction != null)
            {
                this.transaction.Dispose();
            }
        }
    }
}
