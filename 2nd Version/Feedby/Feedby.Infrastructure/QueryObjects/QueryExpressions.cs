namespace Feedby.Infrastructure.QueryObjects
{
    using System;
    using System.Linq.Expressions;

    using Feedby.Infrastructure.Domain;

    public static class QueryExpressions
    {
        #region Expressions
        private static readonly Expression<Func<Employee, string, bool>> EmployeePartialNameExpression = (employee, partialName) => employee.FirstName.ToLowerInvariant().Contains(partialName) || employee.LastName.ToLowerInvariant().Contains(partialName);

        private static readonly Expression<Func<Employee, Guid, bool>> EmployeeIdExpression = (employee, id) => employee.Id.Equals(id);
        #endregion

        #region Compiled Expressions
        public static readonly Func<Employee, Guid, bool> EmployeeId = EmployeeIdExpression.Compile();

        public static readonly Func<Employee, string, bool> EmployeePartialName = EmployeePartialNameExpression.Compile();
        #endregion
        
    }
}
