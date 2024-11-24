using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Models;
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
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;

        public PostsController(IPostRepository postRepository, ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }
        public async Task<IActionResult> Index(string tag)
        {
            var posts = _postRepository.Posts; //tolist dersek veritabınından alır gelir
            if(!string.IsNullOrEmpty(tag)){
                posts = posts.Where(x=>x.Tags.Any(t=>t.Url == tag));
            }
            // var posts = await _context.Posts.ToListAsync();
            return View(
                new PostTagViewModel
                {
                    Posts = await posts.ToListAsync()
                    // Tags = _tagRepository.Tags.ToList()
                }
            );
        }

        public async Task<IActionResult> Details(string url)
        {
            return View(await _postRepository
                                .Posts
                                .Include(x=>x.Tags)
                                .Include(y=>y.Comments)
                                .ThenInclude(u=>u.User)
                                .FirstOrDefaultAsync(p=>p.Url == url));
        }

        public IActionResult AddComment(int PostId, string UserName, string Text)
        {

            return View();
        }
    }
}