using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.ViewComponents
{
    public class GenresViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //var turListesi = new List<Genre>()
            //{
            //    new Genre{Name="Macera"},
            //    new Genre{Name="Komedi"},
            //    new Genre{Name="Korku"},
            //    new Genre{Name="Animasyon"},
            //};
            ViewBag.SelectedGenreId = RouteData.Values["id"];

            return View(GenreRepository.GetGenres);
        }
    }
}
