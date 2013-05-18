namespace Feedby.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;

    using Feedby.Infrastructure.Domain;
    using Feedby.Infrastructure.QueryObjects;
    using Feedby.Infrastructure.Repositories;

    public class EmployeeService : IEmployeeService
    {
        private readonly IEntityRepository<Employee> employeeRepository;

        public EmployeeService(IEntityRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void Delete(Employee entity)
        {
            var query = new EmployeeIdQuery(entity.Id);
            var entityToDelete = this.employeeRepository.Single(query);
            this.employeeRepository.Delete(entityToDelete);
        }

        public Employee Save(Employee entity)
        {
            return this.employeeRepository.Insert(entity);
        }

        public Employee SingleById(Guid id)
        {
            var query = new EmployeeIdQuery(id);
            return this.employeeRepository.Single(query, new[] { "Profile", "Profile.Bio" });
        }

        public IEnumerable<Employee> FilterByName(string name)
        {
            var query = new PartialNameQuery(name);
            return this.employeeRepository.FindBy(query, new[] { "Profile" });
        }

        public Employee SingleByUsername(string username)
        {
            var query = new UsernameQuery(username);
            return this.employeeRepository.Single(query, new[] { "Profile" });
        }
    }
}
