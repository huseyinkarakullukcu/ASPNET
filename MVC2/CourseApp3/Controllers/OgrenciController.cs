using CourseApp3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp3.Controllers
{
    public class OgrenciController:Controller
    {
        private readonly DataContext _context;
        public OgrenciController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
            if(model == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid){
                _context.Ogrenciler.Add(model);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Ogrenciler.ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> Guncelle(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = await _context.Ogrenciler.FirstOrDefaultAsync(x=>x.OgrenciId == id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Guncelle(Ogrenci model)
        {
            if(ModelState.IsValid)
            {
                _context.Ogrenciler.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
            
        }

        public async Task<IActionResult> Sil(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var model = await _context.Ogrenciler.FirstOrDefaultAsync(x=>x.OgrenciId == id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Sil([FromForm]int OgrenciId)
        {
            var model = await _context.Ogrenciler.FirstOrDefaultAsync(x=>x.OgrenciId == OgrenciId);
            if(model == null)
            {
                return NotFound();
            }
            _context.Ogrenciler.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}