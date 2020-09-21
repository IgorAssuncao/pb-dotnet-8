using Context;
using Hortogram.Mappings;
using Hortogram.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        HortogramContext Context { get; set; }

        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task<List<User>> GetUsersByNameOrLastname(string name, string lastname);
        Task<User> GetByEmail(string email);
        Task<User> GetById(Guid id);
        Task<List<User>> GetAll();
        Task<List<UserFollowersResponse>> GetFollowers(User user);
        Task AddFollower(UsersFollowers userFollower);
        Task RemoveFollower(UsersFollowers userFollower);
    }
}