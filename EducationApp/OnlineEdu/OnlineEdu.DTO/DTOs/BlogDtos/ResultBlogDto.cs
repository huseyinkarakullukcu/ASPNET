using OnlineEdu.DTO.DTOs.BlogCategoryDtos;

namespace OnlineEdu.DTO.DTOs.BlogDtos
{
    public class ResultBlogDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime BlogDate { get; set; }
        public int BlogCategoryId { get; set; }
        public ResultBlogCategoryDto BlogCategory { get; set; }
    }
}
