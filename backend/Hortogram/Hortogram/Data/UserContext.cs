using Hortogram.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) {}

        public DbSet<User> UserDbSet { get; set; }
        public DbSet<UsersFollowers> UsersFollowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersFollowers>().HasKey(entity => new { entity.UserId, entity.FollowerId });

            modelBuilder.Entity<UsersFollowers>()
                .HasOne<User>(entity => entity.UserOrFollower)
                .WithMany(entity => entity.Followers)
                .HasForeignKey(entity => entity.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsersFollowers>()
                .HasOne<User>(entity => entity.UserOrFollower)
                .WithMany(entity => entity.Followers)
                .HasForeignKey(entity => entity.FollowerId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
