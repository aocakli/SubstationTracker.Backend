using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Users._Bases.Validators;

namespace SubstationTracker.Application.Features.Users._Bases.Commands.CreateUser;

public class CreateUserCommandRequestValidator : AbstractValidator<CreateUserCommandRequest>
{
    public CreateUserCommandRequestValidator()
    {
        Include(new UserBaseValidator<CreateUserCommandRequest>());

        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .MinimumLength(FieldConsts.PasswordMinLength)
            .Equal(x => x.ConfirmPassword);

        RuleFor(x => x.ConfirmPassword)
            .NotNull()
            .NotEmpty()
            .MinimumLength(FieldConsts.PasswordMinLength)
            .Equal(x => x.Password);

        RuleFor(x => x.Roles)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Roles)
            .Must(x => x.Any(c => c == UserRoleTypes.Unknown) is false)
            .WithMessage(Messages.UserRolesIsUnknown);
    }
}