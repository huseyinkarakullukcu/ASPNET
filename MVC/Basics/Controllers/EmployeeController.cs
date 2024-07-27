using Basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers{
    public class EmployeeController : Controller
    {

        public IActionResult Index()
        {
            string message = $"Hello World. {DateTime.Now.ToString()}";
            return View("Index", message);
        }
        public ViewResult Index2(){
            var names = new String[]
            {
                "Ahmet",
                "Mehmet",
                "Can"
            };
            //string dizi verdiğimizde view e kabul eder
            return View(names);
        }

        public IActionResult Index3(){
            var list = new List<Employee>()
            {
                new Employee(){Id=1, FirstName="Hüseyin", LastName="Karakullukcu", Age=40},
                new Employee(){Id=2, FirstName="Can", LastName="Dağ", Age=25},
                new Employee(){Id=3, FirstName="Kemal", LastName="Güneş", Age=30},
            };
            return View("Index3", list);
        }
    }
}