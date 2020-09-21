using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Hortogram.Models;
using Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hortogram.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        public ICommentService CommentService { get; set; }
        public IPostService PostService { get; set; }

        public CommentController(ICommentService commentService, IPostService postService)
        {
            CommentService = commentService;
            PostService = postService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var comment = await CommentService.GetById(id);

            if (comment == null)
                return BadRequest();

            return Ok(comment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommentsOfAPost(Guid postId)
        {
            var post = await PostService.GetById(postId);

            if (post == null)
                return BadRequest();

            return Ok(await CommentService.GetAllCommentsOfAPost(postId));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentRequest commentReq)
        {
            Guid id = new Guid();

            Comment commentRes = await CommentService.CreateComment(id, commentReq.UserId, commentReq.PostId, commentReq.Content);

            if (commentRes == null)
                return BadRequest();

            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool result = await CommentService.RemoveComment(id);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] Guid id, [FromBody] string content)
        {
            var commentFound = await CommentService.GetById(id);
            var newComment = commentFound;

            if (String.IsNullOrEmpty(content))
                return BadRequest();

            newComment.Content = content;

            bool result = await CommentService.UpdateComment(newComment);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
