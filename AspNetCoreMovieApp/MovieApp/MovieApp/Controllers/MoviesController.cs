using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;

namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            
            string[] oyuncular = { "oyuncu 1", "oyuncu 2", "oyuncu 3" };

            var movie = new Movie();

            movie.Title = "filmBasligi";
            movie.Description = "filmin açıklaması";
            movie.Director = "filmin yönetmen adı";
            movie.Players = oyuncular;

            return View(movie);
        }

        public IActionResult List()
        {
            var filmListesi = new List<Movie>()
            {
                new Movie{
                    Id = 1, 
                    Title = "Film 1", 
                    Description = "Film Açıklaması 1", 
                    Director = "Yönetmen 1", 
                    Players=new string[] { "oyuncu 1", "oyuncu 2" }, 
                    ImageUrl="1.jpg" },
                new Movie{
                    Id = 2, 
                    Title = "Film 2", 
                    Description = "Film Açıklaması 2", 
                    Director = "Yönetmen 2", Players=new string[] { "oyuncu 1", "oyuncu 2" }, 
                    ImageUrl="2.jpg"},
                new Movie{
                    Id = 3, 
                    Title = "Film 3", 
                    Description = "Film Açıklaması 3", 
                    Director = "Yönetmen 3", 
                    Players=new string[] { "oyuncu 1", "oyuncu 2" }, 
                    ImageUrl="3.jpg"},
                new Movie{
                    Id = 4, 
                    Title = "Film 4", 
                    Description = "Film Açıklaması 4", 
                    Director = "Yönetmen 4", 
                    Players=new string[] { "oyuncu 1", "oyuncu 2" }, 
                    ImageUrl="4.jpg"},
            };
            return View(filmListesi);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
