using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using Settings;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthService : IAuthService
    {
        public IUserService UserService { get; set; }

        public JwtSecurityTokenHandler TokenHandler { get; set; }

        public CommonSettings Settings { get; set; }

        public string key;

        public AuthService(IUserService userService, IConfiguration config)
        {
            UserService = userService;
            Settings = new CommonSettings(config);
            key = Settings.GetJwtSecret();
            TokenHandler = new JwtSecurityTokenHandler();
        }

        private string GenerateToken(Guid Id, string email)
        {
            SecurityTokenDescriptor TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, email)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(key)),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Audience = "PB8",
                Issuer = "PB8"
            };
            JwtSecurityToken Token = TokenHandler.CreateJwtSecurityToken(TokenDescriptor);
            TokenHandler.WriteToken(Token);
            return Token.RawData;
        }

        public async Task<AuthenticationReturn> Authenticate(string email, string password)
        {
            User user = await UserService.GetUserByEmail(email);
            if (user == null)
                return new AuthenticationReturn { Status = false };

            if (password != user.Password)
                return new AuthenticationReturn { Status = false };

            string token = GenerateToken(user.Id, user.Email);

            return new AuthenticationReturn { Status = true, Token = token, Id = user.Id };
        }
    }
}
