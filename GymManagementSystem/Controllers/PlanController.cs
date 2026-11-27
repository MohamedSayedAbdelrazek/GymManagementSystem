using GymManagementSystem.Contexts;
using GymManagementSystem.Repositories.Plans;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Controllers
{
    public class PlanController : Controller
    {
        //private GymDbContext _context = new GymDbContext();

        private IplanRepository _planRepository = new PlanRepository();

        public async Task<IActionResult> Index()
        {
            var plans = await _planRepository.GetAllPlansAsync();
            return View(plans);
        }
    }
}
