using Context;
using Models;
using System;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserContext UserDb { get; set; }

        public UserRepository(UserContext userContext)
        {
            UserDb = userContext;
        }

        public void CreateUser(User user)
        {
            UserDb.UserDb.Add(user);
            UserDb.SaveChanges();
        }
    }
}
