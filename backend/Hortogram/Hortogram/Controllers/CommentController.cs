using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hortogram.Controllers
{
    public class CommentController : ControllerBase
    {
        public ICommentService CommentService { get; set; }

        public CommentController(ICommentService commentService)
        {
            CommentService = commentService;
        }

        [HttpGet("{id}")]
        public Comment Get(Guid id)
        {
            var comment = CommentService.GetById(id);

            if (comment == null)
            {
                return null;
            }

            return comment;
        }

        public IActionResult Delete(Guid id)
        {
            bool result = CommentService.RemoveComment(id);

            if (!result)
                return BadRequest();

            return Ok();
        }


    }
}
