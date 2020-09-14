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

        public User CreateUser(Guid Id, string FirstName, string Lastname, string email, string password, string photoUrl, bool status)
        {
            User user = new User(Id, FirstName, Lastname, email, password, photoUrl, status);
            user.Id = Guid.NewGuid();

            try
            {
                UserRepository.CreateUser(user);
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
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


        public bool UpdateUser(Guid id, string firstName, string lastName, string email, string password, string photoUrl)
        {
            try
            {
                var user = UserRepository.GetById(id);

                if (!String.IsNullOrEmpty(firstName))
                {
                    user.FirstName = firstName;
                }
                if (!String.IsNullOrEmpty(lastName))
                {
                    user.Lastname = lastName;
                }
                if (!String.IsNullOrEmpty(email))
                {
                    user.Email = email;
                }
                if (!String.IsNullOrEmpty(password))
                {
                    user.Password = password;
                }
                if (!String.IsNullOrEmpty(photoUrl))
                {
                    user.Password = password;
                }

                UserRepository.UpdateUser(user);
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
