

namespace OnlineEdu.Entity.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public CourseCategory Category { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }
    }
}
