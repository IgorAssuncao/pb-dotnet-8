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

        public PostController(IPostService postService, IImageService imageService)
        {
            PostService = postService;
            ImageService = imageService;
        }

        // GET: api/Post
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Post/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Post
        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] Guid UserId,[FromForm] PostRequest postReq)
        {
            Guid Id = Guid.NewGuid();

            ImageProperties imageProperties = Utils.ConvertImageBase64StringToByteArr(postReq.ImageBase64);

            string photoUrl = await ImageService.UploadFile("post_picture", Id, imageProperties.FileExtension, imageProperties.ImageBytes);

            Post postRes = await PostService.CreatePost(Id, UserId, postReq.Description, photoUrl);

            if (postRes == null)
                return BadRequest();

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
