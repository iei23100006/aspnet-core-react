using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Repositories
{
    public interface IActivityRepository : IAuditableRepositoryBase<Activity>
    {
        Task<(IEnumerable<Activity>, long)> GetActivities(int pageIndex, int pageSize, bool isActive, CancellationToken cancellationToken);
        Task<Activity?> GetActivityByName(string activityName, CancellationToken cancellationToken);
    }
}