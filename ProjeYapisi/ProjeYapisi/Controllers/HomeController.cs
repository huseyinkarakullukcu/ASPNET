using Microsoft.AspNetCore.Mvc;

namespace ProjeYapisi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
