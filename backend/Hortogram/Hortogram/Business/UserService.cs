using Hortogram.Common;
using Hortogram.Mappings;
using Hortogram.Models;
using Models;
using Repositories;
using System;
using System.Collections.Generic;

namespace Services
{
    public class UserService : IUserService
    {
        public IUserRepository UserRepository { get; set; }

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public UserResponse CreateUser(Guid Id, string FirstName, string Lastname, string email, string password, string photoUrl, bool status)
        {
            User user = new User { 
                Id = Id,
                FirstName = FirstName,
                Lastname = Lastname,
                Email = email,
                Password = password,
                PhotoURL = photoUrl,
                Status = status
            };

            try
            {
                UserRepository.CreateUser(user);
                UserResponse userResponse = Utils.ConvertUserToUserResponse(user);
                return userResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public UserResponse GetByEmail(string email)
        {
            try
            {
                User user = UserRepository.GetByEmail(email);
                UserResponse userResponse = Utils.ConvertUserToUserResponse(user);
                return userResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public UserResponse GetById(Guid id)
        {
            try
            {
                User user = UserRepository.GetById(id);
                UserResponse userResponse = Utils.ConvertUserToUserResponse(user);
                return userResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<UserResponse> GetAll()
        {
            List<User> users = UserRepository.GetAll();
            List<UserResponse> usersResponse = new List<UserResponse>();

            foreach(User u in users)
            {
                usersResponse.Add(new UserResponse
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    Lastname = u.Lastname,
                    Email = u.Email,
                    Status = u.Status,
                    PhotoURL = u.PhotoURL
                });
            }

            return usersResponse;
        }

        public bool UpdateUser(Guid id, string firstName, string lastName, string email, string password, string photoUrl)
        {
            try
            {
                var user = UserRepository.GetById(id);

                if (!string.IsNullOrEmpty(firstName))
                {
                    user.FirstName = firstName;
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    user.Lastname = lastName;
                }
                if (!string.IsNullOrEmpty(email))
                {
                    user.Email = email;
                }
                if (!string.IsNullOrEmpty(password))
                {
                    user.Password = password;
                }
                if (!string.IsNullOrEmpty(photoUrl))
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

        public List<UserFollowersResponse> GetFollowers(Guid userId)
        {
            try
            {
                User user = Utils.ConvertUserResponseToUser(GetById(userId));

                if (user == null)
                    return null;

                List<UserFollowersResponse> followers = UserRepository.GetFollowers(user);
                return followers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool AddFollower(Guid userId, Guid followerId)
        {
            try
            {
                if (userId == followerId)
                    return false;

                User user = UserRepository.GetById(userId);
                User follower = UserRepository.GetById(followerId);

                if (user == null || follower == null)
                    return false;

                UsersFollowers userFollower = new UsersFollowers { UserId = userId, FollowerId = followerId };
                UserRepository.AddFollower(userFollower);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool RemoveFollower(Guid userId, Guid followerId)
        {
            try
            {
                User user = UserRepository.GetById(userId);
                User follower = UserRepository.GetById(userId);
                if (user == null || follower == null)
                    return false;

                UsersFollowers userFollower = new UsersFollowers { UserId = userId, FollowerId = followerId };
                UserRepository.RemoveFollower(userFollower);
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
