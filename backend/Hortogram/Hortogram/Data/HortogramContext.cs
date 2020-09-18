using Microsoft.EntityFrameworkCore;
using Models;

namespace Context
{
    public class HortogramContext : DbContext
    {
        public HortogramContext(DbContextOptions<HortogramContext> options) : base(options) {}

        public DbSet<User> UserDbSet { get; set; }

        public DbSet<Post> PostDbSet { get; set; }

        public DbSet<Comment> CommentDbSet { get; set; }
    }
}
