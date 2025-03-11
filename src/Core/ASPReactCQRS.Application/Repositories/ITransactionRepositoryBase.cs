namespace ASPReactCQRS.Application.Repositories
{
    public interface ITransactionRepositoryBase<T> where T : Domain.Common.TransactionBase
    {
        Task CreateAsync(T entity, CancellationToken cancellationToken);
        Task CreateMultipleAsync(List<T> entities, CancellationToken cancellationToken);
        void Update(T entity, CancellationToken cancellationToken);
        void UpdateMultiple(List<T> entities);
        void Delete(T entity, CancellationToken cancellationToken);
        void DeleteMultiple(List<T> entities);
        Task<T?> GetAsync(long id, CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}
