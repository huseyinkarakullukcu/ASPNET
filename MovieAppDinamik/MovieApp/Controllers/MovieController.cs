using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Entity;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieContext _context;
        public MovieController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult list(int? id, string? q)
        {
            //var kelime = HttpContext.Request.Query["q"].ToString();
            var genreId = RouteData.Values["id"];
            //var movies = MovieRepository.GetMovies;
            var movies = _context.Movies.AsQueryable();

            if (id != null)
            {
               movies = movies
                    .Include(m=>m.Genres)
                    .Where(m=>m.Genres.Any(g=>g.GenreId == id));
            }
            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(x=>
                    x.Title.ToLower().Contains(q.ToLower()) || 
                    x.Description.ToLower().Contains(q.ToLower()));
            }

            var model = new MovieViewModel { Movies = movies.ToList() };

            return View(model);


        }

        public IActionResult Details(int id)
        {

            //return View(MovieRepository.GetById(id));
            return View(_context.Movies.Find(id));
        }
    
        
    }

}
