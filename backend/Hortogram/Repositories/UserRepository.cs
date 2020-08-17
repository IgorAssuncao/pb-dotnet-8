using Context;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public IUserContext UserDb { get; set; }

        public UserRepository(IUserContext userContext)
        {
            UserDb = userContext;
        }
    }
}
