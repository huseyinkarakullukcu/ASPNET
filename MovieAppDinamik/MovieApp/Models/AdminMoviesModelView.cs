using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MovieApp.Entity;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class AdminMoviesModelView
    {
        //public List<Movie>  Movies{ get; set; }
        public List<AdminMovieViewModel> Movies { get; set; }
    }

    public class AdminMovieViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public List<Genre> Genres { get; set; }
    }
    public class AdminCreateMovieViewModel
    {
        [Display(Name ="Film Adı")]
        [Required(ErrorMessage ="film adı girmelisiniz.")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Film adı için 3-50 karakter girmelisiniz.")]
        public string Title { get; set; }
        [Display(Name = "Film Açıklama")]
        [Required(ErrorMessage = "film açıklaması girmelisiniz.")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Film açıklama için 3-500 karakter girmelisiniz.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bir film seçmelisiniz.")]
        public int[] GenreIds { get; set; }
    }

    public class AdminEditMovieViewModel
    {
        public int MovieId { get; set; }
        [Display(Name = "Film Adı")]
        [Required(ErrorMessage = "film adı girmelisiniz.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Film adı için 3-50 karakter girmelisiniz.")]
        public string Title { get; set; }
        [Display(Name = "Film Açıklama")]
        [Required(ErrorMessage = "film açıklaması girmelisiniz.")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Film açıklama için 3-500 karakter girmelisiniz.")]
        public string Description { get; set; }
        [ValidateNever]
        public string? Image { get; set; }
        [Required(ErrorMessage = "Bir film seçmelisiniz.")]
        public int[] GenreIds { get; set; }
    }
}