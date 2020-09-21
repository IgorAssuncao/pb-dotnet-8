using System;
using System.Collections.Generic;
using Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using Hortogram.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hortogram.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        public IPostService PostService { get; set; }
        public IImageService ImageService { get; set; }
        public IUserService UserService { get; set; }

        public PostController(IPostService postService, IImageService imageService, IUserService userService)
        {
            PostService = postService;
            ImageService = imageService;
            UserService = userService;
        }

        // GET: api/Post?userId
        [HttpGet]
        public async Task<IActionResult> GetAllPostsOfAUser([FromQuery] Guid userId)
        {
            var user = await UserService.GetById(userId);

            if (user == null)
                return BadRequest();

            return Ok(await PostService.GetAllPostsOfAUser(userId));
        }

        // GET api/Post/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var post = await PostService.GetById(id);

            if (post == null)
                return BadRequest();

            return Ok(post);
        }

        // POST api/Post
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PostRequest postReq)
        {
            Guid Id = Guid.NewGuid();

            ImageProperties imageProperties = Utils.ConvertImageBase64StringToByteArr(postReq.ImageBase64);

            string photoUrl = await ImageService.UploadFile("post_picture", Id, imageProperties.FileExtension, imageProperties.ImageBytes);

            Post postRes = await PostService.CreatePost(Id, postReq.UserId, photoUrl, postReq.Description);

            if (postRes == null)
                return BadRequest();

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] string description)
        {
            Post postFound = await PostService.GetById(id);
            Post newPost = postFound;

            if (String.IsNullOrEmpty(description))
                return BadRequest();

            newPost.Description = description;

            bool result = await PostService.UpdatePost(newPost);

            if (!result)
                return BadRequest();

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool result = await PostService.RemovePost(id);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
