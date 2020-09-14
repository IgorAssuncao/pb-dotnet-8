using System;
using Models;
using Repositories;

namespace Services
{
    public interface IPostService
    {
        IPostRepository PostRepository { get; set; }

        Post CreatePost(Guid Id, Guid UserId, string photoUrl, string description);

        Post GetById(Guid id);

        bool UpdatePost(Guid id, string photoUrl, string description);

        bool RemovePost(Guid id);
    }
}
