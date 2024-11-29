using CourseApp3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp3.Controllers
{
    public class KursController:Controller
    {
        private readonly DataContext _context;
        public KursController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.Kurslar.ToListAsync();
            return View(model);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Kurs model)
        {
            if(model == null)
            {
                return NotFound();
            }
            _context.Kurslar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = await _context.Kurslar.FirstOrDefaultAsync(x=>x.KursId == id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> edit(Kurs model)
        {
            if(model == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Kurslar.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = await _context.Kurslar.FirstOrDefaultAsync(x=>x.KursId == id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int KursId)
        {
            
            var model = await _context.Kurslar.FirstOrDefaultAsync(x=>x.KursId == KursId);
            if(model == null)
            {
                return NotFound();
            }
            _context.Kurslar.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}