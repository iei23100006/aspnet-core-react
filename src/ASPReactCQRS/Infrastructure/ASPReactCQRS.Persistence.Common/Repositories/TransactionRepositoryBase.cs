using ASPReactCQRS.Application.Repositories;
using ASPReactCQRS.Domain.Common;
using ASPReactCQRS.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore;

namespace ASPReactCQRS.Persistence.Common.Repositories
{
    public abstract class TransactionRepositoryBase<T> : ITransactionRepositoryBase<T> where T : TransactionBase
    {
        protected readonly IASPReactCQRSDbContext Context;

        public TransactionRepositoryBase(IASPReactCQRSDbContext context)
        {
            Context = context;
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken)
        {
            await Context.AddAsync(entity, cancellationToken);
        }

        public async Task CreateMultipleAsync(List<T> entities, CancellationToken cancellationToken)
        {
            await Context.AddRangeAsync(entities, cancellationToken);
        }

        public Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return Context.Set<T>().ToListAsync(cancellationToken);
        }

        public Task<T?> GetAsync(long id, CancellationToken cancellationToken)
        {
            return Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Update(T entity, CancellationToken cancellationToken)
        {
            Context.Update(entity);
        }

        public void UpdateMultiple(List<T> entities)
        {
            Context.UpdateRange(entities);
        }

        public void Delete(T entity, CancellationToken cancellationToken)
        {
            Context.Remove(entity);
        }

        public void DeleteMultiple(List<T> entities)
        {
            Context.RemoveRange(entities);
        }
    }
}
