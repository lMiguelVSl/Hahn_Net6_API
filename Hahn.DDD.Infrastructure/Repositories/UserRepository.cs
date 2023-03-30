using Hahn.DDD.Application.Contracts.Persistence;
using Hahn.DDD.Domain;
using Hahn.DDD.Infrastructure.Persistence;

namespace Hahn.DDD.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context)
        {
        }
    }
}
