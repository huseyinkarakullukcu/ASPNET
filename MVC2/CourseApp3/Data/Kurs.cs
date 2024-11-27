using System.ComponentModel.DataAnnotations;

namespace CourseApp3.Data
{
    public class Kurs
    {
        [Key]
        public int KursId { get; set; }
        public string? KursBaslik { get; set; }

    }
}