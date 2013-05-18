namespace Feedby.Infrastructure.Services
{
    using System.Collections.Generic;

    using Feedby.Infrastructure.Domain;

    public interface IEmployeeService : IEntityService<Employee>
    {
        IEnumerable<Employee> FilterByName(string name);

        Employee SingleByUsername(string username);
    }
}
