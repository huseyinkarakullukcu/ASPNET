using System.ComponentModel.DataAnnotations;

namespace CaourseApp3.Data
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciId { get; set; }
        public string? OgrenciAd { get; set; }
        public string? OgrenciSoyad { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
    }
}