using Context;
using Hortogram.Mappings;
using Hortogram.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public HortogramContext Context { get; set; }

        public UserRepository(HortogramContext context)
        {
            Context = context;
        }

        public async Task CreateUser(User user)
        {
            try
            {
                await Context.UserDbSet.AddAsync(user);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                Context.UserDbSet.Update(user);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<User>> GetUsersByNameOrLastname(string name, string lastname)
        {
            return await Context.UserDbSet.Where(user => user.FirstName.Contains(name) || user.Lastname.Contains(lastname)).ToListAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await Context.UserDbSet.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User> GetById(Guid id)
        {
            return await Context.UserDbSet.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await Context.UserDbSet.ToListAsync();
        }

        public async Task<List<UserFollowersResponse>> GetFollowers(User user)
        {
            user.Followers = await Context.UsersFollowers.Where(uf => uf.UserId == user.Id).ToListAsync();

            List<UserFollowersResponse> followers = new List<UserFollowersResponse>();

            foreach(UsersFollowers u in user.Followers) {
                User userFound = await Context.UserDbSet.FirstOrDefaultAsync(user => user.Id == u.FollowerId);
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

        public async Task AddFollower(UsersFollowers userFollower)
        {
            try
            {
                await Context.UsersFollowers.AddAsync(userFollower);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void RemoveFollower(UsersFollowers userFollower)
        {
            try
            {
                Context.UsersFollowers.Remove(userFollower);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
