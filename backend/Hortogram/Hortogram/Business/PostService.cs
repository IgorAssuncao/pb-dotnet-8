using Models;
using Repositories;
using System;
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

        public async Task<bool> UpdatePost(Guid id, string photoUrl, string description)
        {
            try
            {
                var post = await PostRepository.GetById(id);

                if (!String.IsNullOrEmpty(photoUrl))
                {
                    post.PhotoUrl = photoUrl;
                }
                if (!String.IsNullOrEmpty(description))
                {
                    post.Description = description;
                }

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
