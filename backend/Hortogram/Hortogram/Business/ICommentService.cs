using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Repositories;

namespace Services
{
    public interface ICommentService
    {
        ICommentRepository CommentRepository { get; set; }

        Task<Comment> CreateComment(Guid id, Guid userId, Guid postId, string content);

        Task<Comment> GetById(Guid id);

        Task<bool> UpdateComment(Comment comment);

        Task<bool> RemoveComment(Guid id);

        Task<List<Comment>> GetAllCommentsOfAPost(Guid postId);
    }
}
