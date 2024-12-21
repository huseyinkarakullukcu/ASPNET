using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;
        public HomeController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel { PopulerMovies = _context.Movies.ToList() };
            return View(model);
        }

        public IActionResult About()
        {
            //var turListesi = new List<Genre>()
            //{
            //    new Genre{Name="Macera"},
            //    new Genre{Name="Komedi"},
            //    new Genre{Name="Korku"},
            //    new Genre{Name="Animasyon"},
            //};
            return View();
        }

        
    }
}
