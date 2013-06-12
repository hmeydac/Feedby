namespace Ice.Infrastructure.Services
{
    using System;

    using Ice.Infrastructure.DataContext;
    using Ice.Infrastructure.Entities;

    public interface IUserDirectory : IEntityRepository<User>
    {
        User[] GetUsers();

        void AddUser(User expectedUser);

        User GetUser(Guid id);

        void RemoveUser(Guid id);
    }
}