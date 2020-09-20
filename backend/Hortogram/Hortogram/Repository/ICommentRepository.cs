using System;
using System.Collections.Generic;
using Context;
using Models;

namespace Repositories
{
    public interface ICommentRepository
    {
        HortogramContext Context { get; set; }

        void CreateComment(Comment comment);

        void UpdateComment(Comment comment);

        void RemoveComment(Comment comment);

        Comment GetById(Guid id);

        List<Comment> GetAllCommentsOfAPost(Guid postId);
    }
}
