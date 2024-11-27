using CaourseApp3.Data;
using Microsoft.EntityFrameworkCore;

namespace CourseApp3.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public DbSet<Kurs> Kurslar {get; set;} = null!; //nullable için
        public DbSet<Ogrenci> Ogrenciler {get; set;} = null!; //nullable için
        public DbSet<KursKayit> KursKayitlari {get; set;} = null!; //nullable için
    }
}