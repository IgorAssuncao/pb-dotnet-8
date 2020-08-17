using Models;
using Repositories;

namespace Services
{
    public interface IUserService
    {
        IUserRepository UserRepository { get; set; }

        public bool CreateUser(User user);

    }
}