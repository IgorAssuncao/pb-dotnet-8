using System;
using System.Collections.Generic;
using Models;
using Repositories;

namespace Services
{
    public class CommentService : ICommentService
    {
        public ICommentRepository CommentRepository { get; set; }

        public CommentService(ICommentRepository commentRepository)
        {
            CommentRepository = commentRepository;
        }

        public Comment CreateComment(Guid id, Guid userId, Guid postId, string content)
        {
            var comment = new Comment(id, userId, postId, content);

            try
            {
                CommentRepository.CreateComment(comment);
                return comment;

            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Comment GetById(Guid id)
        {
            try
            {
                return CommentRepository.GetById(id);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool RemoveComment(Guid id)
        {
            try
            {
                var comment = CommentRepository.GetById(id);
                CommentRepository.RemoveComment(comment);
                return true;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateComment(Guid id, string content)
        {
            try
            {
                var comment = CommentRepository.GetById(id);

                if (!String.IsNullOrEmpty(content))
                {
                    comment.Content = content;
                }
                CommentRepository.UpdateComment(comment);
                return true;

            } catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<Comment> GetAllCommentsOfAPost(Guid postId)
        {
            try
            {
                var comments = CommentRepository.GetAllCommentsOfAPost(postId);
                return comments;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
