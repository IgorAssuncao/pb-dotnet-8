using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Hortogram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService UserService { get; set; }

        public UserController(IUserService userService)
        {
            UserService = userService;
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
        public IActionResult Post([FromBody] User user)
        {
            bool result = UserService.CreateUser(user);

            return Ok();
        }

        [HttpPost]
        public IActionResult Update([FromBody] User user)
        {
            bool result = UserService.UpdateUser(user);

            return Ok();
        }

        // PUT: api/User/5
        //[HttpPut("{id}")]
        //public IActionResult Put([FromQuery] Guid id, [FromBody] string firstName, string lastName, string email, string password)
        //{
        //    bool result = UserService.UpdateUser(id, firstName, lastName, email, password);

        //    return Ok();
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
