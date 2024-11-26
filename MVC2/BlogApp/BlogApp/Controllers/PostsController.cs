using System.Security.Claims;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
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
        private ICommentRepository _commentRepository;

        public PostsController(IPostRepository postRepository, ITagRepository tagRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
            _commentRepository = commentRepository;
        }
        public async Task<IActionResult> Index(string tag)
        {
            var claims = User.Claims;
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

        
        // public IActionResult AddComment(int PostId, string UserName, string Text, string Url)
        [HttpPost]
        public JsonResult AddComment(int PostId, string Text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);
            var entity = new Comment{
                CommentText = Text,
                PublishedOn = DateTime.Now,
                PostId = PostId,
                UserId = int.Parse(userId ?? "")
                //User = new User{UserName = UserName, Image = "profile.png"}
            };
            _commentRepository.CreateComment(entity);
            // return Redirect("/posts/details/"+Url);
            // return RedirectToRoute("post_details", new {url = Url});
            return Json(new {
                username, 
                Text,
                entity.PublishedOn,
                avatar
            });
        }
    }
}