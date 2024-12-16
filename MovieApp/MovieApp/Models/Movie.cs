using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Display(Name ="Title")]
        [StringLength(50,MinimumLength=5, ErrorMessage= "Must be 5-50 characters")]
        [Required(ErrorMessage = "title required field")]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        [Required]
        public string? Image { get; set; }
        public string[]? Players { get; set; }
        [Required]
        public int? GenreId { get; set; }
    }
}
