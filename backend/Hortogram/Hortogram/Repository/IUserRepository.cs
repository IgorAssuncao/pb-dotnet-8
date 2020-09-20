﻿using Context;
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

        void UpdateUser(User user);

        Task<User> GetByEmail(string email);

        Task<User> GetById(Guid id);

        Task<List<User>> GetAll();

        Task<List<UserFollowersResponse>> GetFollowers(User user);

        Task AddFollower(UsersFollowers userFollower);

        void RemoveFollower(UsersFollowers userFollower);
    }
}