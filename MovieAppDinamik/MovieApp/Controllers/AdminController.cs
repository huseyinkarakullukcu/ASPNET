using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Entity;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly MovieContext _context;
        public AdminController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MovieList()
        {
            return View(new AdminMoviesModelView
            {
                Movies = _context.Movies
                .Include(g => g.Genres)
                .Select(m => new AdminMovieViewModel
                {
                    MovieId = m.Id,
                    Title = m.Title,
                    Image = m.Image,
                    Genres = m.Genres.ToList()
                })
                .ToList()
            }
                );
        }

        public IActionResult MovieUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _context.Movies
                                 .Select(m => new AdminEditMovieViewModel
                                 {
                                     MovieId = m.Id,
                                     Title = m.Title,
                                     Image = m.Image,
                                     Description = m.Description,
                                     GenreIds = m.Genres.Select(i => i.GenreId).ToArray()
                                 }).FirstOrDefault(m => m.MovieId == id);

            ViewBag.Genres = _context.Genres.ToList();

            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> MovieUpdate(AdminEditMovieViewModel model, int[] genreIds, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                var entity = _context.Movies.Include("Genres").FirstOrDefault(m => m.Id == model.MovieId);
                if (entity == null)
                {
                    return NotFound();
                }


                entity.Title = model.Title;
                entity.Description = model.Description;
                if (file != null)
                {
                    var extention = Path.GetExtension(file.FileName); //.jpg, .png
                    var fileName = string.Format($"movie_{Guid.NewGuid()}{extention}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", fileName); //konumu belirttik
                    entity.Image = fileName;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }


                entity.Genres = genreIds.Select(id => _context.Genres.FirstOrDefault(i => i.GenreId == id)).ToList();

                _context.SaveChanges();

                return RedirectToAction("movielist");
            }
            ViewBag.Genres = _context.Genres.ToList();
            return View(model);
        }

        public IActionResult GenreList()
        {
            return View(GetGenres());
        }
        private AdminGenresViewModel GetGenres()
        {
            return new AdminGenresViewModel
            {
                Genres = _context.Genres.Select(g => new AdminGenreViewModel
                {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Count = g.Movies.Count
                }).ToList()
            };
        }
        [HttpPost]
        public IActionResult GenreCreate(AdminGenresViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Genres.Add(new Genre { Name = model.Name });
                _context.SaveChanges();
                return RedirectToAction("GenreList");
            }
            return View("GenreList", GetGenres());
        }

        public IActionResult GenreUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _context.Genres
                                 .Select(g => new AdminGenreEditViewModel
                                 {
                                     GenreId = g.GenreId,
                                     Name = g.Name,
                                     Movies = g.Movies.Select(i => new AdminMovieViewModel
                                     {
                                         MovieId = i.Id,
                                         Title = i.Title,
                                         Image = i.Image,
                                     }).ToList()
                                 }).FirstOrDefault(m => m.GenreId == id);


            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        public IActionResult GenreUpdate(AdminGenreEditViewModel model, int[] movieIds)
        {
            if (ModelState.IsValid)
            {
                var entity = _context.Genres.Include("Movies").FirstOrDefault(i => i.GenreId == model.GenreId);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;

                foreach (var id in movieIds)
                {
                    entity.Movies.Remove(entity.Movies.FirstOrDefault(m => m.Id == id));
                }

                _context.SaveChanges();
                return RedirectToAction("GenreList");
            }

            return View(model);

        }

        [HttpPost]
        public IActionResult GenreDelete(int genreId)
        {
            var entity = _context.Genres.Find(genreId);
            if (entity != null)
            {
                _context.Genres.Remove(entity);
                _context.SaveChanges();
            }
            return RedirectToAction("GenreList");
        }
        [HttpPost]
        public IActionResult MovieDelete(int movieId)
        {
            var entity = _context.Movies.Find(movieId);
            if (entity != null)
            {
                if (entity.Image != null)
                {
                    System.IO.File.Delete("wwwroot/img/" + entity.Image);
                }
                _context.Movies.Remove(entity);
                _context.SaveChanges();

            }
            return RedirectToAction("MovieList");
        }

        public IActionResult MovieCreate()
        {
            ViewBag.Genres = _context.Genres.ToList();
            return View(new AdminCreateMovieViewModel());
        }
        [HttpPost]
        public IActionResult MovieCreate(AdminCreateMovieViewModel model)
        {
            //if(model.GenreIds == null)
            //{
            //    ModelState.AddModelError("GenreIds", "Bir tür seçmelisiniz.");
            //}
            if (ModelState.IsValid)
            {
                var entity = new Movie
                {
                    Title = model.Title,
                    Description = model.Description,
                    Image = "no-image.jpg"
                };
                foreach (var id in model.GenreIds)
                {
                    entity.Genres.Add(_context.Genres.FirstOrDefault(i => i.GenreId == id));
                }
                _context.Movies.Add(entity);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }
            ViewBag.Genres = _context.Genres.ToList();
            return View(model);
        }
    }
}
