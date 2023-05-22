using SubstationTracker.Domain.Concrete.Substations._Bases.Base;

namespace SubstationTracker.Application.Features.Substations._Bases.Validators;

public class SubstationBaseValidator<T> : AbstractValidator<T> where T : ISubstationBase
{
    public SubstationBaseValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.PhoneNumber).NotNull().NotEmpty();
        RuleFor(x => x.Address).NotNull().NotEmpty();
        RuleFor(x => x.Description).NotNull().NotEmpty();
    }
}