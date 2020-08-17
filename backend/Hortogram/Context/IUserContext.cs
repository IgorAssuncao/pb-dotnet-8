using Microsoft.EntityFrameworkCore;
using Models;

namespace Context
{
    public interface IUserContext
    {
        DbSet<User> UserDb { get; set; }
    }
}