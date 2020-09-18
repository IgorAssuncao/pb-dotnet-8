using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("post")]
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("user_id")]
        public Guid UserId { get; set; }

        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public Post()
        {

        }

        public Post(string _PhotoUrl, string _Description)
        {
            PhotoUrl = _PhotoUrl;
            Description = _Description;
        }

        public Post(Guid _Id, string _PhotoUrl, string _Description)
        {
            Id = _Id;
            PhotoUrl = _PhotoUrl;
            Description = _Description;
        }

        public Post(Guid _Id, Guid _UserId, string _PhotoUrl, string _Description)
        {
            Id = _Id;
            UserId = _UserId;
            PhotoUrl = _PhotoUrl;
            Description = _Description;
        }
    }
}
