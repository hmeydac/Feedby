namespace Feedby.Tests.Repositories.Repositories
{
    using System;

    using Feedby.Infrastructure.Domain;
    using Feedby.Infrastructure.QueryObjects;
    using Feedby.Infrastructure.Repositories;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EmployeeRepositoryFixture : TransactionalTest
    {
        [TestMethod]
        public void WhenInsertingEmployeeShouldSaveIt()
        {
            // Arrange
            const string ExpectedFirstName = "FirstName";
            const string ExpectedLastName = "LastName";

            var employeeRepository = new EntityRepository<Employee>(this.Context);
            var employee = CreateEmployee(ExpectedFirstName, ExpectedLastName);

            // Act
            var insertedEmployee = employeeRepository.Insert(employee);
            this.Context.SaveChanges();
            var query = new EmployeeIdQuery(insertedEmployee.Id);
            var actual = employeeRepository.Single(query);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(ExpectedFirstName, actual.FirstName);
            Assert.AreEqual(ExpectedLastName, actual.LastName);
        }

        private static Employee CreateEmployee(string firstName, string lastName)
        {
            var bio = new UserBio { Id = Guid.NewGuid(), BioDescription = "Test" };
            var profile = new UserProfile { Id = Guid.NewGuid(), Bio = bio };
            var employee = new Employee
                               {
                                   Id = Guid.NewGuid(),
                                   FirstName = firstName,
                                   LastName = lastName,
                                   Email = "test@test.com",
                                   Profile = profile,
                                   Username = "tuser"
                               };

            return employee;
        }
    }
}
