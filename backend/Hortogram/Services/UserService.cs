using Models;
using Repositories;
using System;

namespace Services
{
    public class UserService : IUserService
    {
        public IUserRepository UserRepository { get; set; }

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public bool CreateUser(User user)
        {
            user.Id = Guid.NewGuid();

            try
            {
                UserRepository.CreateUser(user);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
