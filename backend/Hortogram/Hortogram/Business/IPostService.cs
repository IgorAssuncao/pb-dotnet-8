using System;
using System.Threading.Tasks;
using Models;
using Repositories;

namespace Services
{
    public interface IPostService
    {
        IPostRepository PostRepository { get; set; }

        Task<Post> CreatePost(Guid Id, Guid UserId, string photoUrl, string description);

        Task<Post> GetById(Guid id);

        Task<bool> UpdatePost(Guid id, string photoUrl, string description);

        Task<bool> RemovePost(Guid id);
    }
}
