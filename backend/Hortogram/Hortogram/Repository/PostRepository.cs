using System;
using System.Linq;
using Context;
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

        public void CreatePost(Post post)
        {
            Context.PostDbSet.Add(post);
            Context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            Context.PostDbSet.Update(post);
            Context.SaveChanges();
        }

        public void RemovePost(Post post)
        {
            Context.PostDbSet.Remove(post);
            Context.SaveChanges();
        }

        public Post GetById(Guid id)
        {
            return Context.PostDbSet.FirstOrDefault(post => post.Id == id);
        }
    }
}
