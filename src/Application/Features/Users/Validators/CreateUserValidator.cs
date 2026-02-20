using Farmify_API_v2.src.Application.Features.Users.Commands;
using FluentValidation;

namespace Farmify_API_v2.src.Application.Features.Users.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
