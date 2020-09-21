using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public HortogramContext Context { get; set; }

        public CommentRepository(HortogramContext context)
        {
            Context = context;
        }

        public async Task CreateComment(Comment comment)
        {
            try
            {
                Context.CommentDbSet.Add(comment);
                await Context.SaveChangesAsync();
            } catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task UpdateComment(Comment comment)
        {
            try
            {
                Context.CommentDbSet.Update(comment);
                await Context.SaveChangesAsync();

            } catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task RemoveComment(Comment comment)
        {
            try
            {
                Context.CommentDbSet.Remove(comment);
                await Context.SaveChangesAsync();
            } catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Comment> GetById(Guid id)
        {

            return await Context.CommentDbSet.FirstOrDefaultAsync(comment => comment.Id == id);
        }

        public async Task<List<Comment>> GetAllCommentsOfAPost(Guid postId)
        {
            return await Context.CommentDbSet.Where(comment => comment.PostId == postId).ToListAsync();
        }
    }
}
