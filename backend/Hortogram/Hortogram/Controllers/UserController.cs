﻿using Hortogram.Common;
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
        public async Task<IActionResult> Get()
        {
            return Ok(await UserService.GetAll());
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await UserService.GetById(id));
        }

        // POST: api/User
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromForm] UserRequest userReq)
        {
            Guid Id = Guid.NewGuid();

            ImageProperties imageProperties = Utils.ConvertImageBase64StringToByteArr(userReq.ImageBase64);

            string photoUrl = await ImageService.UploadFile("profile", Id, imageProperties.FileExtension, imageProperties.ImageBytes);

            userReq.Status = true;
            UserResponse userRes = await UserService.CreateUser(Id, userReq.FirstName, userReq.Lastname, userReq.Email, userReq.Password, photoUrl, userReq.Status);

            if (userRes == null)
                return BadRequest();

            return Ok();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromQuery] Guid id, [FromBody] string firstName, string lastName)
        {
            User userFound = await UserService.GetUserById(id);
            if (userFound == null)
                return BadRequest();

            User newUser = new User();

            newUser.Id = id;

            if (string.IsNullOrEmpty(firstName))
                newUser.FirstName = userFound.FirstName;
            if (string.IsNullOrEmpty(lastName))
                newUser.Lastname = userFound.Lastname;

            newUser.Email = userFound.Email;
            newUser.Password = userFound.Password;
            newUser.PhotoURL = userFound.PhotoURL;

            bool result = await UserService.UpdateUser(id, newUser.FirstName, newUser.Lastname, newUser.Email, newUser.Password, newUser.PhotoURL);

            if (!result)
                return BadRequest();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            User user = await UserService.GetUserById(id);

            if (user == null)
                return BadRequest();

            bool result = await UserService.RemoveUser(user);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [Route("{id}/followers")]
        public async Task<IActionResult> GetFollowers([FromRoute] Guid id)
        {
            return Ok(await UserService.GetFollowers(id));
        }

        [HttpPut]
        [Route("{id}/followers")]
        public async Task<IActionResult> AddFollower([FromRoute] Guid id, [FromBody] FollowerRequest follower)
        {
            bool result = await UserService.AddFollower(id, follower.Id);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}/followers")]
        public async Task<IActionResult> RemoveFollower([FromRoute] Guid id, [FromBody] FollowerRequest follower)
        {
            bool result = await UserService.RemoveFollower(id, follower.Id);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
