using Microsoft.EntityFrameworkCore;
using ASPReactCQRS.Application.Repositories;
using ASPReactCQRS.Domain.Common;
using ASPReactCQRS.Persistence.Common.Context;

namespace ASPReactCQRS.Persistence.Common.Repositories
{
    public abstract class AuditableRepositoryBase<T> : IAuditableRepositoryBase<T> where T : AuditableEntityBase
    {
        protected readonly IASPReactCQRSDbContext Context;

        public AuditableRepositoryBase(IASPReactCQRSDbContext context)
        {
            Context = context;
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken, string? createdById = null)
        {
            // Set CreatedAt to UtcNow
            entity.CreatedAt = DateTime.UtcNow;
            
            // Set CreatedBy if exist
            if (createdById != null)
            {
                entity.CreatedById = createdById;
            }

            await Context.AddAsync(entity, cancellationToken);
        }

        public async Task BulkCreateAsync(T[] entities, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            foreach (var entity in entities)
            {
                entity.CreatedAt = now;
            }
            await Context.AddRangeAsync(entities, cancellationToken);
        }

        public void Update(T entity, string? updatedById, CancellationToken cancellationToken)
        {
            // Set UpdatedAt to UtcNow
            entity.UpdatedAt = DateTime.UtcNow;

            // Set UpdatedBy based on UpdatedById
            entity.UpdatedById = updatedById;
            Context.Update(entity);
        }

        public void UpdateMultiple(List<T> entities)
        {
            Context.UpdateRange(entities);
        }

        public void Delete(T entity, string? deletedById, CancellationToken cancellationToken)
        {
            // Set DeletedAt to UtcNow
            entity.DeletedAt = DateTime.UtcNow;
            
            // Set DeletedBy based on DeletedById
            entity.DeletedById = deletedById;
            Context.Update(entity);
        }

        public void DeleteMultiple(List<T> entities)
        {
            Context.RemoveRange(entities);
        }

        public void Undelete(T entity, string? updatedById, CancellationToken cancellationToken)
        {
            // Set UpdatedBy to current user and DeletedBy to null
            entity.UpdatedAt = DateTime.UtcNow;
            entity.UpdatedById = updatedById;
            entity.DeletedAt = null;
            entity.DeletedById = null;
            Context.Update(entity);
        }

        public Task<T?> GetAsync(long id, CancellationToken cancellationToken)
        {
            return Context.Set<T>()
                .Include(x => x.CreatedBy)
                .Include(x => x.UpdatedBy)
                .Include(x => x.DeletedBy)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return Context.Set<T>()
                .Include(x => x.CreatedBy)
                .Include(x => x.UpdatedBy)
                .Include(x => x.DeletedBy)
                .ToListAsync(cancellationToken);
        }
    }
}
