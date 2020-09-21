using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class PostService : IPostService
    {
        public IPostRepository PostRepository { get; set; }

        public PostService(IPostRepository postRepository)
        {
            PostRepository = postRepository;
        }

        public async Task<Post> CreatePost(Guid id, Guid userId, string photoUrl, string description)
        {
            Post post = new Post(id, userId, photoUrl, description);

            await PostRepository.CreatePost(post);
            return post;
        }

        public async Task<Post> GetById(Guid id)
        {
            return await PostRepository.GetById(id);
        }

        public async Task<List<PostResponse>> GetAllPostsOfAUser(Guid userId)
        {
            List<Post> posts = await PostRepository.GetAllPostsOfAUser(userId);
            List<PostResponse> postResponse = new List<PostResponse>();

            foreach(Post post in posts)
            {
                postResponse.Add(new PostResponse { Id = post.Id, UserId = post.UserId, Description = post.Description, PhotoUrl = post.PhotoUrl });
            }

            return postResponse;
        }

        public async Task<bool> UpdatePost(Post post)
        {
            try
            {
                await PostRepository.UpdatePost(post);
                return true;   
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> RemovePost(Guid id)
        {
            try
            {
                var post = await PostRepository.GetById(id);

                await PostRepository.RemovePost(post);
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
