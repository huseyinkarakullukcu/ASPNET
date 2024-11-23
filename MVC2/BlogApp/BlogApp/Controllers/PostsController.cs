using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class PostsController:Controller
    {
        // private readonly BlogContext _context;
        // public PostsController(BlogContext context)
        // {
        //     _context = context;
        // }
        private IPostRepository _repository;

        public PostsController(IPostRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            // var posts = await _context.Posts.ToListAsync();
            return View(_repository.Posts.ToList());
        }
    }
}