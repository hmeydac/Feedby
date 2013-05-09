namespace Feedby.Infrastructure.QueryObjects
{
    using System;

    using Feedby.Infrastructure.Domain;

    public class PartialNameQuery : QueryObject<Employee>
    {
        public PartialNameQuery(string partialName) : base(false)
        {
            this.PartialName = partialName;
        }

        public string PartialName { get; set; }
        
        public override Func<Employee, bool> GetQuery()
        {
            return (e) => QueryExpressions.EmployeePartialName(e, this.PartialName.ToLowerInvariant());
        }
    }
}
