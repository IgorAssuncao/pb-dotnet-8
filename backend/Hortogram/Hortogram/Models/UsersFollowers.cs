using Models;
using System;

namespace Hortogram.Models
{
    public class UsersFollowers
    {
        public Guid UserId { get; set; }
        public User UserOrFollower { get; set; }
        public Guid FollowerId { get; set; }
    }
}
