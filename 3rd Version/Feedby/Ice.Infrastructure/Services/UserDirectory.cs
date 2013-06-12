namespace Ice.Infrastructure.Services
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Diagnostics;
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

            return this.GetExpandedUserQuery().OrderBy(DefaultSortExpression).Skip(skipCount).Take(takeCount).ToArray();
        }

        public void AddUser(User expectedUser)
        {
            this.DataSet.Add(expectedUser);
        }

        public User GetUser(Guid id)
        {
            Func<User, bool> query = (u) => UserIdQuery(u, id);
            return this.GetExpandedUserQuery().SingleOrDefault(query);
        }

        public bool CommitChanges()
        {
            try
            {
                return this.Context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return false;
        }

        public void RemoveUser(Guid id)
        {
            var removeEntity = this.GetUser(id);
            this.DataSet.Remove(removeEntity);
        }

        private DbQuery<User> GetExpandedUserQuery()
        {
            return this.DataSet.Include("Profile");
        }
    }
}