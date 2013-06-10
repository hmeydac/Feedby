namespace Ice.Infrastructure.Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Ice.Infrastructure.Entities;

    public class UserDirectory : IUserDirectory
    {
        private static readonly Expression<Func<User, object>> DefaultSortExpression = (user) => user.LastName;
        private static readonly Expression<Func<User, Guid, bool>> UserIdExpression = (user, id) => user.Id.Equals(id);

        private static readonly Func<User, object> DefaultSortQuery = DefaultSortExpression.Compile();
        private static readonly Func<User, Guid, bool> UserIdQuery = UserIdExpression.Compile();

        public UserDirectory(DbContext context)
        {
            this.Context = context;
            this.DataSet = context.Set<User>();
        }

        public DbContext Context { get; set; }

        public DbSet<User> DataSet { get; set; }

        public User[] GetUsers()
        {
            return this.DataSet.OrderBy(DefaultSortQuery).ToArray();
        }

        public User[] GetUsers(int pageNumber, int resultsPerPage)
        {
            var skipCount = (pageNumber - 1) * resultsPerPage;
            var takeCount = resultsPerPage;

            return this.DataSet.OrderBy(DefaultSortExpression).Skip(skipCount).Take(takeCount).ToArray();
        }

        public void AddUser(User expectedUser)
        {
            this.DataSet.Add(expectedUser);
        }

        public User GetUser(Guid id)
        {
            Func<User, bool> query = (u) => UserIdQuery(u, id);
            return this.DataSet.SingleOrDefault(query);
        }

        public bool CommitChanges()
        {
            return this.Context.SaveChanges() > 0;
        }

        public void RemoveUser(Guid id)
        {
            var removeEntity = this.GetUser(id);
            this.DataSet.Remove(removeEntity);
        }
    }
}