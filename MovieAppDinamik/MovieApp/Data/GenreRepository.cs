using MovieApp.Models;

namespace MovieApp.Data
{
    public class GenreRepository
    {
        public static readonly List<Genre> _genres = null;

        static GenreRepository()
        {
            _genres = new List<Genre>()
            {
                new Genre{GenreId=1, Name="Macera"},
                new Genre{GenreId=2, Name="Komedi"},
                new Genre{GenreId=3, Name="Korku"},
                new Genre{GenreId=4, Name="Drama"},
                new Genre{GenreId=5, Name="Suç"},
                new Genre{GenreId=6, Name="Aksiyon"}
            };
           
        }

        public static List<Genre> GetGenres
        {
           get{ return _genres; }
        }

        public static void AddGenre(Genre genre)
        {
            _genres.Add(genre);
        }

        public static Genre GetById(int id)
        {
            return _genres.FirstOrDefault(x => x.GenreId == id);
        }
    }
}
