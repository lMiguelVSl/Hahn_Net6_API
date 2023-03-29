using Hahn.DDD.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hahn.DDD.Infrastructure
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
