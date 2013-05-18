namespace Feedby.Infrastructure.QueryObjects
{
    using System;

    using Feedby.Infrastructure.Domain;

    public class UsernameQuery : QueryObject<Employee>
    {
        public UsernameQuery(string username)
            : base(false)
        {
            this.Username = username;
        }

        public string Username { get; set; }

        public override Func<Employee, bool> GetQuery()
        {
            return (e) => QueryExpressions.EmployeeUsername(e, this.Username);
        }
    }
}
