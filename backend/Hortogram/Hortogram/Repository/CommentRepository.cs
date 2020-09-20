using System;
using System.Collections.Generic;
using System.Linq;
using Context;
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

        public void CreateComment(Comment comment)
        {
            Context.CommentDbSet.Add(comment);
            Context.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            Context.CommentDbSet.Update(comment);
            Context.SaveChanges();
        }

        public void RemoveComment(Comment comment)
        {
            Context.CommentDbSet.Remove(comment);
            Context.SaveChanges();
        }

        public Comment GetById(Guid id)
        {
            return Context.CommentDbSet.FirstOrDefault(comment => comment.Id == id);
        }

        public List<Comment> GetAllCommentsOfAPost(Guid postId)
        {
            return Context.CommentDbSet.Where(comment => comment.PostId == postId).ToList();
        }
    }
}
