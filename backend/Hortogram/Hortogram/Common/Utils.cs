using Hortogram.Mappings;
using Models;

namespace Hortogram.Common
{
    public static class Utils
    {
        public static UserResponse ConvertUserToUserResponse(User user)
        {
            UserResponse userResponse = new UserResponse
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    Lastname = user.Lastname,
                    Email = user.Email,
                    Status = user.Status,
                    PhotoURL = user.PhotoURL
                };
            return userResponse;
        }

        public static User ConvertUserResponseToUser(UserResponse userResponse)
        {
            User user = new User
            {
                Id = userResponse.Id,
                FirstName = userResponse.FirstName,
                Lastname = userResponse.Lastname,
                Email = userResponse.Email,
                Password = null,
                Status = userResponse.Status,
                PhotoURL = userResponse.PhotoURL
            };

            return user;
        }
    }
}
