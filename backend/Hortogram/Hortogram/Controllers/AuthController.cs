using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Hortogram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuthService AuthService { get; set; }

        public AuthController(IAuthService authService)
        {
            AuthService = authService;
        }

        // GET: api/Auth
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Auth/5
        [HttpGet("{id}", Name = "GetAuth")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Auth
        [HttpPost]
        public IActionResult Post([FromBody] LoginAttributes loginAttributes)
        {
            //AuthService
            AuthenticationReturn auth = AuthService.Authenticate(loginAttributes.Email, loginAttributes.Password);
            if (!auth.Status)
                return BadRequest(auth);

            return Ok(auth);
        }

        // PUT: api/Auth/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class LoginAttributes
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginAttributes()
        {
        }

        public LoginAttributes(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
