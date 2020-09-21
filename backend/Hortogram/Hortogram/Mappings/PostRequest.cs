using System;
namespace Models
{
    public class PostRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ImageBase64 { get; set; }
        public string Description { get; set; }

        public PostRequest()
        {
        }

        public PostRequest(Guid userId, string description, string imageBase64)
        {
            UserId = userId;
            Description = description;
            ImageBase64 = imageBase64;
        }
    }
}
