using Context;
using Hortogram.Mappings;
using Hortogram.Models;
using Models;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IUserRepository
    {
        HortogramContext Context { get; set; }

        void CreateUser(User user);

        void UpdateUser(User user);

        User GetByEmail(string email);

        User GetById(Guid id);

        List<User> GetAll();

        List<UserFollowersResponse> GetFollowers(User user);

        void AddFollower(UsersFollowers userFollower);

        void RemoveFollower(UsersFollowers userFollower);
    }
}