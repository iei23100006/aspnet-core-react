namespace ASPReactCQRS.Application.Repositories
{
    public interface IDbTransaction : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
