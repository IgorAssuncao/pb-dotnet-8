using Models;
using Repositories;

namespace Services
{
    public interface IUserService
    {
        IUserRepository UserRepository { get; set; }

        bool CreateUser(User user);

        User GetByEmail(string email);
    }
}