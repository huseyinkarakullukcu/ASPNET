using Microsoft.AspNetCore.Mvc;

namespace ProjeYapisi.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
