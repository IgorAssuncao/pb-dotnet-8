using Context;
using Hortogram.Mappings;
using Hortogram.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public HortogramContext Context { get; set; }

        public UserRepository(HortogramContext context)
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

        public List<User> GetAll()
        {
            return Context.UserDbSet.ToList();
        }

        public List<UserFollowersResponse> GetFollowers(User user)
        {
            user.Followers = Context.UsersFollowers.Where(uf => uf.UserId == user.Id).ToList();

            List<UserFollowersResponse> followers = new List<UserFollowersResponse>();

            foreach(UsersFollowers u in user.Followers) {
                User userFound = Context.UserDbSet.FirstOrDefault(user => user.Id == u.FollowerId);
                followers.Add(new UserFollowersResponse {
                    Id = userFound.Id,
                    FirstName = userFound.FirstName,
                    Lastname = userFound.Lastname,
                    Email = userFound.Email,
                    Status = userFound.Status,
                    PhotoURL = userFound.Password
                });
            }

            return followers;
        }

        public void AddFollower(UsersFollowers userFollower)
        {
            Context.UsersFollowers.Add(userFollower);
            Context.SaveChanges();
        }

        public void RemoveFollower(UsersFollowers userFollower)
        {
            Context.UsersFollowers.Remove(userFollower);
            Context.SaveChanges();
        }
    }
}
