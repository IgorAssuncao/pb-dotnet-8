using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using Settings;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
                Expires = DateTime.UtcNow.AddHours(1),
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

        public AuthenticationReturn Authenticate(string email, string password)
        {
            User user = UserService.GetByEmail(email);
            if (user == null)
                return new AuthenticationReturn { Status = false };

            if (password != user.Password)
                return new AuthenticationReturn { Status = false };

            string token = GenerateToken(user.Id, user.Email);

            return new AuthenticationReturn { Status = true, Token = token, Id = user.Id };
        }
    }

    public class AuthenticationReturn
    {
        public bool Status { get; set; }
        public string Token { get; set; }
        public Guid Id { get; set; }
    }
}
