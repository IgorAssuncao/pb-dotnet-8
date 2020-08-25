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

        public void UpdateUser(User outdatedUser, User updatedUser)
        {
            UserDb.UserDb.Remove(outdatedUser);
            UserDb.UserDb.Add(updatedUser);
            UserDb.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return UserDb.UserDb.FirstOrDefault(user => user.Email == email);
        }

        public User GetById(Guid id)
        {
            return UserDb.UserDb.FirstOrDefault(user => user.Id == id);
        }
    }
}
