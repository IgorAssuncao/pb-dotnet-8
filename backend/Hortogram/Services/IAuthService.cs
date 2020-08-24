using Repositories;

namespace Services
{
    public interface IAuthService
    {
        IUserService UserService { get; set; }

        public AuthenticationReturn Authenticate(string email, string password);
    }
}