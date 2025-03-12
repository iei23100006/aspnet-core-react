using ASPReactCQRS.Application.Repositories;
using ASPReactCQRS.Domain.Entities;
using ASPReactCQRS.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore;

namespace ASPReactCQRS.Persistence.Common.Repositories
{
    public class ActivityRepository : AuditableRepositoryBase<Activity>, IActivityRepository
    {
        public ActivityRepository(IASPReactCQRSDbContext context) : base(context)
        {
        }

        public async Task<(IEnumerable<Activity>, long)> GetActivities(int pageIndex, int pageSize, bool isActive, CancellationToken cancellationToken)
        {
            var activities = new List<Activity>();
            var total = 0;

            var query = Context.Set<Activity>()
                                .Include(c => c.CreatedBy)
                                .Include(c => c.UpdatedBy)
                                .Include(c => c.DeletedBy)
                                .AsQueryable();

            if (isActive)
            {
                activities = await query
                                    .Where(x => x.DeletedAt == null)
                                    .AsNoTracking()
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync(cancellationToken)
                                    .ConfigureAwait(false);

                total = await query
                                    .Where(x => x.DeletedAt == null)
                                    .AsNoTracking()
                                    .CountAsync(cancellationToken)
                                    .ConfigureAwait(false);
            } else {
                activities = await query
                                    .Where(x => x.DeletedAt != null)
                                    .AsNoTracking()
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync(cancellationToken)
                                    .ConfigureAwait(false);

                total = await query
                                    .Where(x => x.DeletedAt != null)
                                    .AsNoTracking()
                                    .CountAsync(cancellationToken)
                                    .ConfigureAwait(false);
            }

            return (activities, total);
        }

        public async Task<Activity?> GetActivityByName(string activityName, CancellationToken cancellationToken)
        {
            return await Context.Set<Activity>()
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.ActivityName == activityName, cancellationToken)
                                .ConfigureAwait(false);
        }
    }
}