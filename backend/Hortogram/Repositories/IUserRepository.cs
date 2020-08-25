using System;
using Context;
using Models;

namespace Repositories
{
    public interface IUserRepository
    {
        UserContext UserDb { get; set; }

        void CreateUser(User user);

        void UpdateUser(User user);

        User GetByEmail(string email);

        User GetById(Guid id);
    }
}