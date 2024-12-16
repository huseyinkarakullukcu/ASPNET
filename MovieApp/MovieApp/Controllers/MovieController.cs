using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult list(int? id, string? q)
        {
            //var kelime = HttpContext.Request.Query["q"].ToString();
            var genreId = RouteData.Values["id"];
            var movies = MovieRepository.GetMovies;
            
            if(id != null)
            {
               movies = movies.Where(m=>m.GenreId == id).ToList();
            }
            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(x=>
                    x.Title.ToLower().Contains(q.ToLower()) || 
                    x.Description.ToLower().Contains(q.ToLower())).ToList();
            }

            var model = new MovieViewModel { Movies = movies };

            return View(model);


        }

        public IActionResult Details(int id)
        {

            return View(MovieRepository.GetById(id));
        }
    
        public IActionResult AddMovie()
        {
            ViewBag.Genre = new SelectList(GenreRepository.GetGenres, "GenreId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie model)
        {
            if (ModelState.IsValid)
            {
                MovieRepository.AddMovie(model);
                TempData["message"] = $"{model.Title} movie is added";
                return RedirectToAction("List");
            }
            ViewBag.Genre = new SelectList(GenreRepository.GetGenres, "GenreId", "Name");
            return View(model);
        }

        public IActionResult EditMovie(int id)
        {
            ViewBag.Genre = new SelectList(GenreRepository.GetGenres, "GenreId","Name");
            var model = MovieRepository.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie model)
        {
            if (ModelState.IsValid)
            {
                MovieRepository.EditMovie(model);
                TempData["message"] = $"{model.Title} movie is updated";
                return RedirectToAction("Details", "Movie", new { @id = model.Id });
            }
            ViewBag.Genre = new SelectList(GenreRepository.GetGenres, "GenreId", "Name");
            return View(model);
            
        }

        [HttpPost]
        public IActionResult MovieDelete(int id, string Title)
        {
            MovieRepository.MovieDelete(id);
            TempData["message"] = $"{Title} movie is deleted";
            return RedirectToAction("List");
        }
    }

}
