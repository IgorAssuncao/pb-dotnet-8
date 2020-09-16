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

        // POST: api/Auth
        [HttpPost]
        public IActionResult Post([FromBody] LoginAttributes loginAttributes)
        {
            //AuthService
            AuthenticationReturn auth = AuthService.Authenticate(loginAttributes.Email, loginAttributes.Password);
            if (!auth.Status)
                return BadRequest(auth);

            return Ok(new { auth.Token });
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
