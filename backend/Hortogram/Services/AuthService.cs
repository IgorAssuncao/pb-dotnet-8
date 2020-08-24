using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using Repositories;
using Settings;
using System;
using System.Collections.Generic;
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

        private string GenerateToken(Guid Id)
        {
            SecurityTokenDescriptor TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken Token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(Token);
        }

        public AuthenticationReturn Authenticate(string email, string password)
        {
            var user = UserService.GetByEmail(email);
            if (user == null)
                return new AuthenticationReturn { Status = false };

            string token = GenerateToken(user.Id);

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
