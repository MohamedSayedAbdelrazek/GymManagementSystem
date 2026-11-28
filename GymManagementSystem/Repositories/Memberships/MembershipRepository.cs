using GymManagementSystem.Contexts;
using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GymManagementSystem.Repositories.Memberships
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly GymDbContext _dbContext;

        public MembershipRepository(GymDbContext dbContext)
        => _dbContext = dbContext;
        
        public Task<bool> AnyAsync(Expression<Func<Membership, bool>> expression, CancellationToken ct)
            => _dbContext.Memberships.AnyAsync(expression, ct);
        
    }
}
