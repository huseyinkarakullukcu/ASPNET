using System.Security.Claims;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Authorization;
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
            var posts = _postRepository.Posts.Where(i=>i.IsActive); //tolist dersek veritabınından alır gelir
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
                                .Include(x=>x.User) //post u kim yayonlamış
                                .Include(x=>x.Tags)
                                .Include(y=>y.Comments)
                                .ThenInclude(u=>u.User) //kimler yorum bırakmış
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

        [Authorize]
        public IActionResult Create()
        {
            // if(!User.Identity!.IsAuthenticated)
            // {
            //     return RedirectToAction("Login","Users");
            // }
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(PostCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _postRepository.CreatePost(
                    new Post{
                        Title = model.Title,
                        Description = model.Description,
                        Content = model.Content,
                        Url = model.Url,
                        UserId = int.Parse(userId ?? ""),
                        PublishedOn = DateTime.Now,
                        Image = "1.jpg",
                        IsActive = false
                    }
                );
                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> List()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var role = User.FindFirstValue(ClaimTypes.Role);

            var posts = _postRepository.Posts;

            if(string.IsNullOrEmpty(role))
            {
                posts = posts.Where(p=>p.UserId == userId);
            }
            
            return View(await posts.ToListAsync());
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var post = _postRepository.Posts.Include(t=>t.Tags).FirstOrDefault(i=>i.PostId == id);
            if(post == null){
                return NotFound();
            }
            ViewBag.Tags = _tagRepository.Tags.ToList();
            return View(
                new PostCreateViewModel{
                    PostId = post.PostId,
                    Title = post.Title,
                    Description = post.Description,
                    Content = post.Content,
                    Url = post.Url,
                    IsActive = post.IsActive,
                    Tags = post.Tags
                }
            );
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(PostCreateViewModel model, int[] tagIds)
        {
            if(ModelState.IsValid)
            {
                var entityToUpdate = new Post{
                    PostId = model.PostId,
                    Title = model.Title,
                    Description = model.Description,
                    Content = model.Content,
                    Url = model.Url
                };
                if(User.FindFirstValue(ClaimTypes.Role) == "admin"){
                    entityToUpdate.IsActive = model.IsActive;
                }
                _postRepository.EditPost(entityToUpdate);
                return RedirectToAction("List");
            }
            ViewBag.Tags = _tagRepository.Tags.ToList();
            return View(model);
        }
    }
}