using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;
using System.Collections.Generic;

namespace Hortogram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        public IUserService UserService { get; set; }
        public IImageService ImageService { get; set; }

        public UserController(IUserService userService, IImageService imageService)
        {
            UserService = userService;
            ImageService = imageService;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public string Get(Guid id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] User user, string ImageBase64)
        // public IActionResult Post([FromBody] string FirstName, string Lastname, string Email, string Password,  image)
        {
            bool userRes = UserService.CreateUser(user);
            // User user = UserService.CreateUser(FirstName, Lastname, Email, Password);

            if (!userRes)
                return BadRequest();

            // ImageService.UploadFile(user.Id, image);

            return Ok();
        }

        [HttpPost]
        [Route("/api/User/createimage")]
        public IActionResult CreateImage([FromBody] string image)
        {
            var res = Convert.FromBase64String(image);
            return Ok();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put([FromQuery] Guid id, [FromBody] string firstName, string lastName, string email, string password)
        {
            bool result = UserService.UpdateUser(id, firstName, lastName, email, password);

            if (!result)
                return BadRequest();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
