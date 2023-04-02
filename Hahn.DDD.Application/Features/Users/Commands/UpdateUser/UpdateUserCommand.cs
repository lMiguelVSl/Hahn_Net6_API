using MediatR;

namespace Hahn.DDD.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Company { get; set; }
    }
}
