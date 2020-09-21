using Models;
using System;
using System.Collections.Generic;

namespace Services
{
    public class PostResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public List<CommentResponse> Comment { get; set; }
    }
}