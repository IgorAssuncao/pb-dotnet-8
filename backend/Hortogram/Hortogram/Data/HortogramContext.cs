using Hortogram.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Context
{
    public class HortogramContext : DbContext
    {
        public HortogramContext(DbContextOptions<HortogramContext> options) : base(options) {}

        public DbSet<User> UserDbSet { get; set; }
        public DbSet<UsersFollowers> UsersFollowers { get; set; }
        public DbSet<Post> PostDbSet { get; set; }
        public DbSet<Comment> CommentDbSet { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(entity => entity.Email).IsUnique();

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

            modelBuilder.Entity<Post>()
                .HasOne<User>(entity => entity.User)
                .WithMany(entity => entity.Posts)
                .HasForeignKey(entity => entity.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne<User>(entity => entity.User)
                .WithMany(entity => entity.Comments)
                .HasForeignKey(entity => entity.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne<Post>(entity => entity.Post)
                .WithMany(entity => entity.Comments)
                .HasForeignKey(entity => entity.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
