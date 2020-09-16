using Models;
using Repositories;
using System;

namespace Services
{
    public interface IUserService
    {
        IUserRepository UserRepository { get; set; }

        User CreateUser(Guid Id, string firstName, string lastName, string email, string password, string photoUrl, bool status);

        User GetByEmail(string email);

        User GetById(Guid id);

        bool UpdateUser(Guid id, string firstName, string lastName, string email, string password, string photoUrl);

        bool RemoveUser(User user);
    }
}