using Context;
using Models;
using System;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IPostRepository
    {
        HortogramContext Context { get; set; }

        Task CreatePost(Post post);

        Task UpdatePost(Post post);

        Task RemovePost(Post post);

        Task<Post> GetById(Guid id);
    }
}
