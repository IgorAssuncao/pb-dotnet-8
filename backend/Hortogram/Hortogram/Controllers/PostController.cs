using System;
using System.Collections.Generic;
using Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

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
        public IActionResult Post([FromQuery] Guid UserId,[FromForm] PostRequest postReq)
        {
            byte[] res = new byte[] { 0 };
            string fileExtension = "";
            if (postReq.ImageBase64 != null)
            {
                string[] imageBase64Splitted = postReq.ImageBase64.Split(',');
                fileExtension = imageBase64Splitted[0].Split(':')[1].Split(';')[0].Split('/')[1];
                string imageBase64 = imageBase64Splitted[1];
                res = Convert.FromBase64String(imageBase64);
            }

            Guid Id = Guid.NewGuid();

            string photoUrl = ImageService.UploadFile("post_picture", Id, fileExtension, res);

            Post postRes = PostService.CreatePost(Id, UserId, postReq.Description, photoUrl);

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
