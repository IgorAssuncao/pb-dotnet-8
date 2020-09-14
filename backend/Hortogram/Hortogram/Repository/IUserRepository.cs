﻿using Context;
using Models;
using System;

namespace Repositories
{
    public interface IUserRepository
    {
        HortogramContext Context { get; set; }

        void CreateUser(User user);

        void UpdateUser(User user);

        User GetByEmail(string email);

        User GetById(Guid id);
    }
}