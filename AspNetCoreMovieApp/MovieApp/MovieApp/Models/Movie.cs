﻿namespace MovieApp.Web.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public string[]? Players { get; set; }
        public string? ImageUrl { get; set; }
    }
}