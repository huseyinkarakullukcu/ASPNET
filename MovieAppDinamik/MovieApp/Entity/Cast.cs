using System.ComponentModel.DataAnnotations;

namespace MovieApp.Entity
{
    public class Cast
    {
        [Key]
        public int CastId { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
    }
}
