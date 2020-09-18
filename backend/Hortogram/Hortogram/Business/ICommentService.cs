using System;
using System.Collections.Generic;
using Models;
using Repositories;

namespace Services
{
    public interface ICommentService
    {
        ICommentRepository CommentRepository { get; set; }

        Comment CreateComment(Guid id, Guid userId, Guid postId, string content);

        Comment GetById(Guid id);

        bool UpdateComment(Guid id, string content);

        bool RemoveComment(Guid id);

        List<Comment> GetAllCommentsOfAPost(Guid postId);
    }
}
