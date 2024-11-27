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

        //1 => 5 öğrenci, 8 nolu kurs
    }
}