using MovieApp.Entity;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Entity
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public string? Imdb { get; set; }
        public string? HomePage { get; set; }
        public string? PlaceOfBirth { get; set; }
        public User? User { get; set; } //Buradaki kayıtlar user tablosunda da olmasını istiyorsak.
        public int UserId { get; set; } //foreign key, unique key
    }
}
