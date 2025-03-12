namespace ASPReactCQRS.Application.Repositories
{
    public interface IAuditableRepositoryBase<T> where T : Domain.Common.AuditableEntityBase
    {
        Task CreateAsync(T entity, CancellationToken cancellationToken, string? createdById = null);
        void Update(T entity, string? updatedById, CancellationToken cancellationToken);
        void UpdateMultiple(List<T> entities);
        void Delete(T entity, string? deletedById, CancellationToken cancellationToken);
        void DeleteMultiple(List<T> entities);        
        void Undelete(T entity, string? updatedById, CancellationToken cancellationToken);
        Task<T?> GetAsync(long id, CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}
