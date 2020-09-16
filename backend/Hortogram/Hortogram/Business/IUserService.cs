﻿using Hortogram.Mappings;
using Models;
using Repositories;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IUserService
    {
        IUserRepository UserRepository { get; set; }

        UserResponse CreateUser(Guid Id, string firstName, string lastName, string email, string password, string photoUrl, bool status);

        UserResponse GetByEmail(string email);

        UserResponse GetById(Guid id);

        List<UserResponse> GetAll();

        bool UpdateUser(Guid id, string firstName, string lastName, string email, string password, string photoUrl);

        bool RemoveUser(User user);

        List<UserFollowersResponse> GetFollowers(Guid userId);

        bool AddFollower(Guid userId, Guid followerId);

        bool RemoveFollower(Guid userId, Guid followerId);
    }
}