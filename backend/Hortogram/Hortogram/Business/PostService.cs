using Models;
using Repositories;
using System;
using System.Collections.Generic;

namespace Services
{
    public class PostService : IPostService
    {
        public IPostRepository PostRepository { get; set; }

        public PostService(IPostRepository postRepository)
        {
            PostRepository = postRepository;
        }

        public Post CreatePost(Guid id, Guid userId, string photoUrl, string description)
        {
            Post post = new Post(id, userId, photoUrl, description);

            try
            {
                PostRepository.CreatePost(post);
                return post;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Post GetById(Guid id)
        {
            try
            {
                return PostRepository.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool UpdatePost(Guid id, string photoUrl, string description)
        {
            try
            {
                var post = PostRepository.GetById(id);

                if (!String.IsNullOrEmpty(photoUrl))
                {
                    post.PhotoUrl = photoUrl;
                }
                if (!String.IsNullOrEmpty(description))
                {
                    post.Description = description;
                }

                PostRepository.UpdatePost(post);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool RemovePost(Guid id)
        {
            try
            {
                var post = PostRepository.GetById(id);

                PostRepository.RemovePost(post);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
