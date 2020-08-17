using Context;

namespace Repositories
{
    public interface IUserRepository
    {
        IUserContext UserDb { get; set; }
    }
}