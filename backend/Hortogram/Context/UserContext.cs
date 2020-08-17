using Microsoft.EntityFrameworkCore;
using Models;

namespace Context
{
    public class UserContext : DbContext, IUserContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> UserDb { get; set; }
    }
}
