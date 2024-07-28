using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = Repository.Applications;
            return View(model);
        }
        public IActionResult Apply()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm] Candidate model)
        {
            if(Repository.Applications.Any(x=>x.Email.Equals(model.Email))){
                ModelState.AddModelError("","There is already an application for you");
            }
            //hata mesajı geçerli olursa valid den geçmez
            if(ModelState.IsValid)
            {
                 Repository.Add(model);
                return View("Feedback", model);
            }
           return View();
        }
    }
    
}