using Repositories;

namespace Services
{
    public interface IAuthService
    {
        IUserRepository UserRepository { get; set; }
    }
}