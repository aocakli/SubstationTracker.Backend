using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories._Bases.Commands.CreateInventory;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories.OtherFeatures.InventoryOuts.Commands.
    CreateInventoryOut;

public class CreateInventoryOutCommandRequestValidator : AbstractValidator<CreateInventoryOutCommandRequest>
{
    public CreateInventoryOutCommandRequestValidator()
    {
        RuleFor(x => x.Inventory)
            .NotNull()
            .NotEmpty()
            .SetValidator(new CreateInventoryCommandRequestValidator());
    }
}