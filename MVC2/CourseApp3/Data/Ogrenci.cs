using System.ComponentModel.DataAnnotations;

namespace CourseApp3.Data
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }
        public string? OgrenciAd { get; set; }
        public string? OgrenciSoyad { get; set; }
        public string? AdSoyad { get{return this.OgrenciAd +" "+ this.OgrenciSoyad;} }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
    }
}