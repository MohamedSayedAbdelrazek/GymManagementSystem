
using GymManagementSystem.Contexts;
using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Repositories.Plans
{
    public class PlanRepository : IplanRepository
    {
        private readonly GymDbContext _dbContext;
        public PlanRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Plan>> GetAllPlansAsync(CancellationToken ct = default)
            => await _dbContext.Plans.AsNoTracking().ToListAsync();
    }
}
