using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.DDD.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name cannot be empty")
                                .NotNull()
                                .MaximumLength(50).WithMessage("Name cannot be bigger than 50 characters");

            RuleFor(p => p.Company).NotEmpty().WithMessage("Company name cannot be empty");
            RuleFor(p => p.Company).NotEmpty().WithMessage("Company name cannot be empty");

        }
    }
}
