namespace Feedby.Infrastructure.QueryObjects
{
    using System;

    using Feedby.Infrastructure.Domain;

    public class EmployeeIdQuery : QueryObject<Employee>
    {
        public EmployeeIdQuery(Guid id)
            : base(false)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }

        public override Func<Employee, bool> GetQuery()
        {
            return (e) => QueryExpressions.EmployeeId(e, this.Id);
        }
    }
}
