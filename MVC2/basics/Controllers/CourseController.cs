using basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace basics.Controllers;

public class CourseController:Controller{
    public IActionResult Index(){
        var kurs = new Course();
        kurs.Id = 1;
        kurs.Title = "Aspnet Core Eğitimi";
        kurs.Description = "Aspnet Core Kursu Açıklaması";
        kurs.Image = "1.jpg";
        return View(kurs);
    }

    public IActionResult List(){
        var kurslar = new List<Course>()
        {
            new Course(){Id = 1, Title="Aspnet Kursu", Description="Aspnet Core Açıklaması", Image="1.jpg"},
            new Course(){Id = 2, Title="Javascript Kursu", Description="Javascript  Açıklaması", Image="2.jpg"},
            new Course(){Id = 3, Title="Django Kursu", Description="Django Kursu Açıklaması", Image="3.jpg"},
            new Course(){Id = 4, Title="Python Kursu", Description="Python Kursu Açıklaması", Image="4.jpg"},
        };
        return View("CourseList", kurslar); //View deki course list gönderir    
    }
}