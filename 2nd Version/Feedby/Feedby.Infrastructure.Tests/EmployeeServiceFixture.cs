namespace Feedby.Infrastructure.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Feedby.Infrastructure.Domain;
    using Feedby.Infrastructure.QueryObjects;
    using Feedby.Infrastructure.Repositories;
    using Feedby.Infrastructure.Services;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class EmployeeServiceFixture
    {
        [TestMethod]
        public void WhenRetrievingEmployeeByIdShouldReturnSingleEmployee()
        {
            // Arrange
            var expectedId = Guid.NewGuid();
            var employeeRepositoryMock = new Mock<IEntityRepository<Employee>>(MockBehavior.Strict);
            employeeRepositoryMock.Setup(r => r.Single(It.IsAny<IQueryObject<Employee>>()))
                                  .Returns(new Employee { Id = expectedId });
            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            // Act
            var actual = employeeService.SingleById(expectedId);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedId, actual.Id);
            employeeRepositoryMock.Verify(r => r.Single(It.IsAny<IQueryObject<Employee>>()), Times.Once());
        }

        [TestMethod]
        public void WhenFilterEmployeesByNameShouldReturnEmployees()
        {
            // Arrange
            var employeeList = this.GetEmployeeList();
            var argument = "arcos";
            var expectedList = employeeList.Where(e => e.FirstName.Contains(argument) || e.LastName.Contains(argument)).ToList();
            var employeeRepositoryMock = new Mock<IEntityRepository<Employee>>(MockBehavior.Strict);
            employeeRepositoryMock.Setup(r => r.FindBy(It.IsAny<IQueryObject<Employee>>()))
                                  .Returns(expectedList);
            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            // Act
            var actual = employeeService.FilterByName(argument);

            // Assert
            Assert.IsNotNull(actual);
            CollectionAssert.AreEqual(expectedList, actual.ToList());
            employeeRepositoryMock.Verify(r => r.FindBy(It.IsAny<IQueryObject<Employee>>()), Times.Once());
        }

        private IEnumerable<Employee> GetEmployeeList()
        {
            return new List<Employee>
                       {
                           new Employee { FirstName = "Hernan", LastName = "Tarcos", Id = Guid.NewGuid() },
                           new Employee { FirstName = "German", LastName = "Enriquez",Id = Guid.NewGuid() },
                           new Employee { FirstName = "Jorge", LastName = "Barcos", Id = Guid.NewGuid() },
                           new Employee { FirstName = "Marcos", LastName = "Castany", Id = Guid.NewGuid() },
                       };
        }
    }
}
