﻿using System.ComponentModel.DataAnnotations;

namespace MovieApp.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public Person? Person { get; set; }
    }
    

}