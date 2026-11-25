using GymManagementSystem.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Controllers
{
    public class PlanController : Controller
    {
        private GymDbContext _context = new GymDbContext();

        public async Task<IActionResult> Index()
        {
            var plans =await _context.Plans.ToListAsync();
            return View(plans);
        }
    }
}
