using Repositories;

namespace Services
{
    public interface IUserService
    {
        IUserRepository UserRepository { get; set; }
    }
}