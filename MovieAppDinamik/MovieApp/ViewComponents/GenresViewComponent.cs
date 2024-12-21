﻿using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.ViewComponents
{
    public class GenresViewComponent:ViewComponent
    {
        private readonly MovieContext _context;
        public GenresViewComponent(MovieContext context)
        {
            _context = context;
        }
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

            //return View(GenreRepository.GetGenres);
            return View(_context.Genres.ToList());
        }
    }
}
