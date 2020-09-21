using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Context;
using Models;

namespace Repositories
{
    public interface ICommentRepository
    {
        HortogramContext Context { get; set; }

        Task CreateComment(Comment comment);

        Task UpdateComment(Comment comment);

        Task RemoveComment(Comment comment);

        Task<Comment> GetById(Guid id);

        Task<List<Comment>> GetAllCommentsOfAPost(Guid postId);
    }
}
