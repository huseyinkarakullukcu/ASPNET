using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;


namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepositoryManager _manager;

        public ProductController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        //public ProductController(RepositoryContext context)
        //{
        //    _context = context;
        //}

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
            var model = _manager.Product.GetAllProducts(false);
            return View(model);
        }

        public IActionResult Get(int id){
            //Product product = _context.Products.First(p => p.ProductId.Equals(id));
            var model = _manager.Product.GetOneProduct(id, false);
            return View(model);
        }
    }
    
}