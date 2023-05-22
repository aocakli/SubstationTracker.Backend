using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories.
    _Bases.Commands.CreateInventory;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories
    .OtherFeatures.InventoryEntries.Commands.
    CreateInventoryEntry;

public class CreateInventoryEntryCommandRequestValidator : AbstractValidator<CreateInventoryEntryCommandRequest>
{
    public CreateInventoryEntryCommandRequestValidator()
    {
        RuleFor(x => x.Inventory)
            .NotNull()
            .NotEmpty()
            .SetValidator(new CreateInventoryCommandRequestValidator());

        RuleFor(x => x.Inventory.TotalPrice)
            .GreaterThan(0);
    }
}