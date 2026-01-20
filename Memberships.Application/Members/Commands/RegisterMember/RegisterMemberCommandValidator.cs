using FluentValidation;

namespace Memberships.Application.Members.Commands.RegisterMember;

public class RegisterMemberCommandValidator
    : AbstractValidator<RegisterMemberCommand>
{
    public RegisterMemberCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.FullName)
            .NotEmpty()
            .MinimumLength(3);
    }
}
