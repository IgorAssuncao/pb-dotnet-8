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

        public User GetByEmail(string email)
        {
            try
            {
                return UserRepository.GetByEmail(email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public User GetById(Guid id)
        {
            try
            {
                return UserRepository.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool UpdateUser(Guid id, string firstName, string lastName, string email, string password)
        {
            try
            {
                var outdatedUser = UserRepository.GetById(id);
                var updatedUser = new User(id, firstName, lastName, email, password);
                UserRepository.UpdateUser(outdatedUser, updatedUser);
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
