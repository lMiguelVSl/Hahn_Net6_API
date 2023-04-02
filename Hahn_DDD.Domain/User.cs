using Hahn.DDD.Domain.Common;

namespace Hahn.DDD.Domain
{
    public class User : BaseDomainModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Company { get; set; }
    }
}
