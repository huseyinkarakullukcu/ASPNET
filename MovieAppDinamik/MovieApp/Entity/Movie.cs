using System.ComponentModel.DataAnnotations;

namespace MovieApp.Entity
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string Director { get; set; }
        public string Image { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}
