namespace Feedby.Tests.Repositories.Services
{
    using System;

    using Feedby.Infrastructure.Domain;
    using Feedby.Infrastructure.Repositories;
    using Feedby.Infrastructure.Services;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EmployeeServiceFixture : TransactionalTest
    {
        [TestMethod]
        public void GetEmployeeById()
        {
            // Arrange
            var repository = new EntityRepository<Employee>(this.Context);
            var employeeService = new EmployeeService(repository);
            var expectedFirstName = "TestName";
            var expectedLastName = "TestLastName";
            var expectedEmail = "test@test.com";
            var employee = this.CreateEmployee(expectedFirstName, expectedLastName, expectedEmail);
            var savedEmployee = employeeService.Save(employee);

            // Act
            var actual = employeeService.SingleById(savedEmployee.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedFirstName, actual.FirstName);
            Assert.AreEqual(expectedLastName, actual.LastName);
            Assert.IsNotNull(actual.Profile);
            Assert.IsNotNull(actual.Profile.Bio);
        }

        private Employee CreateEmployee(string firstName, string lastName, string email)
        {
            var bio = new UserBio { Id = Guid.NewGuid(), BioDescription = "Test" };
            var profile = new UserProfile { Id = Guid.NewGuid(), Bio = bio };
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Profile = profile
            };
            return employee;
        }
    }
}
