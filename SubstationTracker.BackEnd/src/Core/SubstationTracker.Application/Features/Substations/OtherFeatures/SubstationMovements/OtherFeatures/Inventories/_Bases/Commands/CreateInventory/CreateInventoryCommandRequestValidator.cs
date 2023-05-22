using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Validators;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories._Bases.Commands.CreateInventory;

public class CreateInventoryCommandRequestValidator : AbstractValidator<CreateInventoryCommandRequest>
{
    public CreateInventoryCommandRequestValidator()
    {
        RuleFor(x => x.ProductId).NotNull().NotEmpty();
        RuleFor(x => x.Quantity).NotNull().NotEmpty();
        RuleFor(x => x.TotalPrice).NotNull();
        RuleFor(x => x.Description);

        Include(new CreateSubstationMovementDtoValidator());
    }
}