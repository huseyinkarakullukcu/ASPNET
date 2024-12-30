using System.ComponentModel.DataAnnotations;

namespace MovieApp.Entity
{
    public class Movie
    {
        public Movie()
        {
            Genres = new List<Genre>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string Image { get; set; }

        public List<Genre> Genres { get; set; } 

    }
}
