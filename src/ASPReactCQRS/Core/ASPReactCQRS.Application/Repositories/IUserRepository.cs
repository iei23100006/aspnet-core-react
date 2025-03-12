using ASPReactCQRS.Domain.Entities;

namespace ASPReactCQRS.Application.Repositories
{
    public interface IUserRepository 
    {
        void Create(User entity);
        Task<User?> Get(string id, CancellationToken cancellationToken);
        Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
        Task<List<User>> GetAll(CancellationToken cancellationToken);
    }
}
