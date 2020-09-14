using Models;
using Repositories;
using System;

namespace Services
{
    public interface IUserService
    {
        IUserRepository UserRepository { get; set; }

        bool CreateUser(User user);

        User CreateUser(string firstName, string lastName, string email, string password);

        User GetByEmail(string email);

        User GetById(Guid id);

        bool UpdateUser(Guid id, string firstName, string lastName, string email, string password);
    }
}