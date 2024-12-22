using System.ComponentModel.DataAnnotations;

namespace MovieApp.Entity
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        public string? Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
