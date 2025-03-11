using ASPReactCQRS.Application.Repositories;
using ASPReactCQRS.Domain.Entities;
using ASPReactCQRS.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore;

namespace ASPReactCQRS.Persistence.Common.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly IASPReactCQRSDbContext Context;
        public UserRepository(IASPReactCQRSDbContext context) 
        {
            Context = context;
        }

        public void Create(User entity)
        {
            Context.Add(entity);
        }

        public Task<User?> Get(string id, CancellationToken cancellationToken)
        {
            return Context.Users.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<List<User>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
        {
            return Context.Set<User>().FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
    }
}
