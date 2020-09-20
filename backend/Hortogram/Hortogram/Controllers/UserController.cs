using Hortogram.Mappings;
using Hortogram.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public IActionResult Get()
        {
            return Ok(UserService.GetAll());
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(Guid id)
        {
            return Ok(UserService.GetById(id));
        }

        // POST: api/User
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromForm] UserRequest userReq)
        {
            byte[] res = new byte[] { 0 };
            string fileExtension = "";
            if (userReq.ImageBase64 != null)
            {
                string[] imageBase64Splitted = userReq.ImageBase64.Split(',');
                fileExtension = imageBase64Splitted[0].Split(':')[1].Split(';')[0].Split('/')[1];
                string imageBase64 = imageBase64Splitted[1];
                res = Convert.FromBase64String(imageBase64);
            }

            Guid Id = Guid.NewGuid();

            string photoUrl = await ImageService.UploadFile("profile", Id, fileExtension, res);

            UserResponse userRes = await UserService.CreateUser(Id, userReq.FirstName, userReq.Lastname, userReq.Email, userReq.Password, photoUrl, userReq.Status);

            //if (userRes == null)
            //    return BadRequest();

            return Ok();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put([FromQuery] Guid id, [FromBody] string firstName, string lastName, string email, string password, string photoUrl)
        {
            User userFound = UserService.GetUserById(id);
            User newUser = new User();

            newUser.Id = id;

            if (String.IsNullOrEmpty(firstName))
                newUser.FirstName = userFound.FirstName;
            if (String.IsNullOrEmpty(lastName))
                newUser.Lastname = userFound.Lastname;
            if (String.IsNullOrEmpty(email))
                newUser.Email = userFound.Email;
            if (String.IsNullOrEmpty(password))
                newUser.Password = userFound.Password;
            if (String.IsNullOrEmpty(photoUrl))
                newUser.PhotoURL = userFound.PhotoURL;

            bool result = UserService.UpdateUser(id, firstName, lastName, email, password, photoUrl);

            if (!result)
                return BadRequest();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            User user = UserService.GetUserById(id);

            bool result = UserService.RemoveUser(user);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [Route("{id}/followers")]
        public IActionResult GetFollowers([FromRoute] Guid id)
        {
            return Ok(UserService.GetFollowers(id));
        }

        [HttpPut]
        [Route("{id}/followers")]
        public IActionResult AddFollower([FromRoute] Guid id, [FromBody] FollowerRequest follower)
        {
            bool result = UserService.AddFollower(id, follower.Id);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}/followers")]
        public IActionResult RemoveFollower([FromRoute] Guid id, [FromBody] FollowerRequest follower)
        {
            bool result = UserService.RemoveFollower(id, follower.Id);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
