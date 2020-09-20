using System.Threading.Tasks;

namespace Services
{
    public interface IAuthService
    {
        IUserService UserService { get; set; }

        Task<AuthenticationReturn> Authenticate(string email, string password);
    }
}