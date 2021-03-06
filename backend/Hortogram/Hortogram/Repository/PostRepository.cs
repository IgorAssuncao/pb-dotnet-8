﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context;
using Hortogram.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories

{
    public class PostRepository : IPostRepository
    {
        public HortogramContext Context { get; set; }

        public PostRepository(HortogramContext context)
        {
            Context = context;
        }

        public async Task<List<Post>> BuildFeed(Guid userId)
        {
            List<UsersFollowers> followers = await Context.UsersFollowers.Where(uf => uf.UserId == userId).ToListAsync();
            List<Guid> followersGuids = new List<Guid>();
            foreach(UsersFollowers uf in followers)
            {
                followersGuids.Add(uf.FollowerId);
            }
            return await Context.PostDbSet.Where(post => post.UserId != userId && followersGuids.Any(followerGuid => followerGuid == post.UserId)).ToListAsync();
        }

        public async Task CreatePost(Post post)
        {
            try
            {
                Context.PostDbSet.Add(post);
                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task UpdatePost(Post post)
        {
            try
            {
                Context.PostDbSet.Update(post);
                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task RemovePost(Post post)
        {
            try
            {
                Context.PostDbSet.Remove(post);
                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Post> GetById(Guid id)
        {
            return await Context.PostDbSet.FirstOrDefaultAsync(post => post.Id == id);
        }

        public async Task<List<Post>> GetAllPostsOfAUser(Guid userId)
        {
            return await Context.PostDbSet.Where(post => post.UserId == userId).ToListAsync();
        }
    }
}
