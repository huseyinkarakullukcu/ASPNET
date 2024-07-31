using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;


namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly RepositoryContext _context;

        public ProductController(RepositoryContext context)
        {
            _context = context;
        }

        // public IEnumerable<Product> Index()
        // {
        //     // var context = new RepositoryContext(
        //     //     new DbContextOptionsBuilder<RepositoryContext>()
        //     //         .UseSqlite("Data Source = C:\\Users\\hk\\Desktop\\ASPNET\\MVC\\ProductDb.db")
        //     //         .Options);
        //     return _context.Products;
        // }
        public IActionResult Index()
        {
            var model =  _context.Products.ToList();
            return View(model);
        }

        public IActionResult Get(int id){
            Product product = _context.Products.First(p => p.ProductId.Equals(id));
            return View(product);
        }
    }
    
}