using Context;
using Models;
using System;
using System.Linq;

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

        public User GetByEmail(string email)
        {
            return UserDb.UserDb.FirstOrDefault(user => user.Email == email);
        }
    }
}
