
using GymManagementSystem.Contexts;
using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Repositories.Plans
{
    public class PlanRepository : IplanRepository
    {
        private readonly GymDbContext _dbContext = new GymDbContext();

        public async Task<IEnumerable<Plan>> GetAllPlansAsync(CancellationToken ct = default)
            => await _dbContext.Plans.AsNoTracking().ToListAsync();
    }
}
