using Hahn.DDD.Domain;

namespace Hahn.DDD.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
