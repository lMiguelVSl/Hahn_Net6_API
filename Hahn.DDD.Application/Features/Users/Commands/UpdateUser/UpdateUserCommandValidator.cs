using FluentValidation;

namespace Hahn.DDD.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name cannot be empty")
                    .NotNull()
                    .MaximumLength(50).WithMessage("Name cannot be bigger than 50 characters");

            RuleFor(p => p.Position).NotEmpty().WithMessage("Position name cannot be empty");
            RuleFor(p => p.Company).NotEmpty().WithMessage("Company name cannot be empty");
        }
    }
}
