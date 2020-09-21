using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Comment> CreateComment(Guid id, Guid userId, Guid postId, string content)
        {
            var comment = new Comment(id, userId, postId, content);

            try
            {
                await CommentRepository.CreateComment(comment);
                return comment;

            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<Comment> GetById(Guid id)
        {
            try
            {
                return await CommentRepository.GetById(id);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> RemoveComment(Guid id)
        {
            try
            {
                var comment = await CommentRepository.GetById(id);
                await CommentRepository.RemoveComment(comment);
                return true;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> UpdateComment(Comment comment)
        {
            try
            {
                await CommentRepository.UpdateComment(comment);
                return true;

            } catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<List<Comment>> GetAllCommentsOfAPost(Guid postId)
        {
            try
            {
                var comments = await CommentRepository.GetAllCommentsOfAPost(postId);
                return comments;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
