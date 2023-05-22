using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;

namespace SubstationTracker.Persistence.EntityConfigurations.Substations.OtherEntityConfigurations.SubstationMovements.OtherConfigurations.Inventories.OtherConfigurations.InventoryOuts;

public class InventoryOutEntityTypeConfiguration : IEntityTypeConfiguration<InventoryOut>
{
    public void Configure(EntityTypeBuilder<InventoryOut> builder)
    {
        builder.HasKey(_inventoryOut => _inventoryOut.Id);

        builder.Property(_inventoryOut => _inventoryOut.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_inventoryOut => _inventoryOut.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.HasQueryFilter(_inventoryOut => _inventoryOut.Inventory!.SubstationMovement!.IsDeleted == false);

        builder.HasOne(_inventoryOut => _inventoryOut.Inventory)
            .WithOne(_inventory => _inventory.InventoryOut)
            .HasForeignKey<InventoryOut>(_inventoryOut => _inventoryOut.Id);

        builder.HasOne(_inventoryOut => _inventoryOut.Audit)
            .WithOne(_audit => _audit.InventoryOut)
            .HasForeignKey<InventoryOut>(_inventoryOut => _inventoryOut.AuditId);
    }
}