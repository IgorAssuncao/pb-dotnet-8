using System;
using System.Collections.Generic;
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

        Task<List<PostResponse>> GetAllPostsOfAUser(Guid userId);

        Task<bool> UpdatePost(Post post);

        Task<bool> RemovePost(Guid id);
    }
}
