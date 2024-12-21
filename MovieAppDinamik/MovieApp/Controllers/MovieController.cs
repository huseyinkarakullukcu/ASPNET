using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
               movies = movies.Where(m=>m.GenreId == id);
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
    
        public IActionResult AddMovie()
        {
            ViewBag.Genre = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie model)
        {
            if (ModelState.IsValid)
            {
                //MovieRepository.AddMovie(model);
                _context.Movies.Add(model);
                _context.SaveChanges();
                TempData["message"] = $"{model.Title} movie is added";
                return RedirectToAction("List");
            }
            ViewBag.Genre = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View(model);
        }

        public IActionResult EditMovie(int id)
        {
            ViewBag.Genre = new SelectList(_context.Genres.ToList(), "GenreId","Name");
            var model = _context.Movies.Find(id); //MovieRepository.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie model)
        {
            if (ModelState.IsValid)
            {
                //MovieRepository.EditMovie(model);
                _context.Movies.Update(model);
                _context.SaveChanges();
                TempData["message"] = $"{model.Title} movie is updated";
                return RedirectToAction("Details", "Movie", new { @id = model.Id });
            }
            ViewBag.Genre = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View(model);
            
        }

        [HttpPost]
        public IActionResult MovieDelete(int id, string Title)
        {
            //MovieRepository.MovieDelete(id);
            var entity = _context.Movies.Find(id);
            _context.Movies.Remove(entity);
            _context.SaveChanges();
            TempData["message"] = $"{Title} movie is deleted";
            return RedirectToAction("List");
        }
    }

}
