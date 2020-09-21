using Models;
using System;

namespace Services
{
    public class PostResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
    }
}