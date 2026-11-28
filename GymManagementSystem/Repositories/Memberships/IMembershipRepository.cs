using GymManagementSystem.Entities;
using System.Linq.Expressions;

namespace GymManagementSystem.Repositories.Memberships
{
    public interface IMembershipRepository
    {
        Task<bool> AnyAsync(Expression<Func<Membership,bool>> expression, CancellationToken ct);
    }
}
