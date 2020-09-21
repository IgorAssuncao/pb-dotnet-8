using System;

namespace Hortogram.Models
{
    public class CommentRequest
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }
    }
}
