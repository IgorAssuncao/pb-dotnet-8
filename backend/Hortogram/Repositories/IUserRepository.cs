using Context;
using Models;

namespace Repositories
{
    public interface IUserRepository
    {
        UserContext UserDb { get; set; }

        void CreateUser(User user);

        User GetByEmail(string email);
    }
}