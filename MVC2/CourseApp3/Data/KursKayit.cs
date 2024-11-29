using System.ComponentModel.DataAnnotations;

namespace CourseApp3.Data
{
    public class KursKayit
    {
        [Key]
        public int KayitId { get; set; }
        public int OgrenciId { get; set; }
        public int KursId { get; set; }
        public DateTime KayitTarihi { get; set; }
        public Ogrenci Ogrenci { get; set; } = null!;
        public Kurs Kurs { get; set; } = null!;

        //1 => 5 öğrenci, 8 nolu kurs
    }
}