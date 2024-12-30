using Microsoft.EntityFrameworkCore;
using MovieApp.Entity;

namespace MovieApp.Data
{
    public class MovieContext:DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options):base(options) //dışarıdan connection string verme
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=movies.db");
        //}
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Cast> Casts { get; set; }

    }
}
