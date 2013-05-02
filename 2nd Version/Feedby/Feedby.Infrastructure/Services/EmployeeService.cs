namespace Feedby.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;

    using Feedby.Infrastructure.Domain;
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
            var entityToDelete = this.employeeRepository.GetById(entity.Id);
            this.employeeRepository.Delete(entityToDelete);
        }

        public Employee Save(Employee entity)
        {
            return this.employeeRepository.Insert(entity);
        }

        public Employee GetById(Guid id)
        {
            return this.employeeRepository.GetById(id);
        }

        public IEnumerable<Employee> FilterByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
