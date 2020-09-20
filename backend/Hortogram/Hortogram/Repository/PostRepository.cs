using System;
using System.Linq;
using System.Threading.Tasks;
using Context;
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

        public async Task CreatePost(Post post)
        {
            try
            {
                await Context.PostDbSet.AddAsync(post);
                Context.SaveChanges();
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
                Context.SaveChanges();
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
                Context.SaveChanges();
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
    }
}
