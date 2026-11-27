using GymManagementSystem.Entities;

namespace GymManagementSystem.Repositories.Plans
{
    public interface IplanRepository
    {
         Task<IEnumerable<Plan>> GetAllPlansAsync(CancellationToken ct =default);
    }
}
