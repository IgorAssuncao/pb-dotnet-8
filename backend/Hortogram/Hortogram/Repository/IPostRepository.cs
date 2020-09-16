﻿using Context;
using Models;
using System;

namespace Repositories
{
    public interface IPostRepository
    {
        HortogramContext Context { get; set; }

        void CreatePost(Post post);

        void UpdatePost(Post post);

        void RemovePost(Post post);

        Post GetById(Guid id);
    }
}