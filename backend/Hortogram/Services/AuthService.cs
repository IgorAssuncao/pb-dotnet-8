using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class AuthService : IAuthService
    {
        public IUserRepository UserRepository { get; set; }

        public AuthService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
    }
}
