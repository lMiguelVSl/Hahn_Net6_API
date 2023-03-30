using FluentValidation;

namespace Hahn.DDD.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator() {
            
        }
    }
}
