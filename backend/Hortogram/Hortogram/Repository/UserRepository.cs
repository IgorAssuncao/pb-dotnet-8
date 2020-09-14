using Context;
using Models;
using System;
using System.Linq;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserContext Context { get; set; }

        public UserRepository(UserContext context)
        {
            Context = context;
        }

        public void CreateUser(User user)
        {
            Context.UserDbSet.Add(user);
            Context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            Context.UserDbSet.Update(user);
            Context.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return Context.UserDbSet.FirstOrDefault(user => user.Email == email);
        }

        public User GetById(Guid id)
        {
            return Context.UserDbSet.FirstOrDefault(user => user.Id == id);
        }
    }
}
