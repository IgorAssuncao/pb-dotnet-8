﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("user")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhotoURL { get; set; }
        public bool? Status { get; set; }

        public User()
        {
        }

        public User(string _FirstName, string _Lastname, string _Email, string _Password, string _PhotoURL)
        {
            FirstName = _FirstName;
            Lastname = _Lastname;
            Email = _Email;
            Password = _Password;
            PhotoURL = _PhotoURL;
        }

        public User(string _FirstName, string _Lastname, string _Email, string _Password, string _PhotoURL, bool _Status)
        {
            FirstName = _FirstName;
            Lastname = _Lastname;
            Email = _Email;
            Password = _Password;
            PhotoURL = _PhotoURL;
            Status = _Status;
        }

        public User(Guid _Id, string _FirstName, string _Lastname, string _Email, string _Password, string _PhotoURL, bool _Status)
        {
            Id = _Id;
            FirstName = _FirstName;
            Lastname = _Lastname;
            Email = _Email;
            Password = _Password;
            PhotoURL = _PhotoURL;
            Status = _Status;
        }
    }
}
