using GymManagementSystem.Contexts;
using GymManagementSystem.Repositories.Memberships;
using GymManagementSystem.Repositories.Plans;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Controllers
{
    public class PlanController : Controller
    {
        //private GymDbContext _context = new GymDbContext();

        //private IplanRepository _planRepository = new PlanRepository();

        private readonly IplanRepository _planRepository;
        private readonly IMembershipRepository _membershipRepository;
        public PlanController(IplanRepository planRepository, IMembershipRepository membershipRepository)
        {
            _planRepository = planRepository;
            _membershipRepository = membershipRepository;
        }

        public async Task<IActionResult> Index()
        {
            var plans = await _planRepository.GetAllPlansAsync();
            return View(plans);
        }

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id, CancellationToken ct)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Plan Not Found!";
                return RedirectToAction(nameof(Index));
            }
                
            var plan = await _planRepository.GetPlanByIdAsync(id,ct);

            if(plan is null)
            {
                TempData["ErrorMessage"] = "Plan Cannot Not Found!";
                return RedirectToAction(nameof(Index));
            }

            if(!plan.IsActive)
            {
                TempData["ErrorMessage"] = "Plan Cannot be edited!";
                return RedirectToAction(nameof(Index));
            }

            //Active Membership ??????
            var hasActiveMembership = await _membershipRepository.AnyAsync(m => m.PlanId == id && m.EndDate > DateTime.Now, ct);
            if(hasActiveMembership)
            {
                TempData["ErrorMessage"] = "Plan Cannot be edited!";
                return RedirectToAction(nameof(Index));
            }

            return View(plan);
        }

        #endregion

    }
}
