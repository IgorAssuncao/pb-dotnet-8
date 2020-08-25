using System;
using Models;
using Repositories;

namespace Services
{
    public interface IUserService
    {
        IUserRepository UserRepository { get; set; }

        bool CreateUser(User user);

        User GetByEmail(string email);

        User GetById(Guid id);

        bool UpdateUser(User user);
    }
}