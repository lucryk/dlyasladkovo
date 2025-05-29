using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelGuide.Data;
using TravelGuide.Models;

namespace TravelGuide.Controllers
{
    public class AttractionsController : Controller
    {
        private readonly AppDbContext _context;

        public AttractionsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attraction = await _context.Attractions
                .Include(a => a.City)
                .FirstOrDefaultAsync(m => m.Id == id);
                
            if (attraction == null)
            {
                return NotFound();
            }

            return View(attraction);
        }
    }
}
