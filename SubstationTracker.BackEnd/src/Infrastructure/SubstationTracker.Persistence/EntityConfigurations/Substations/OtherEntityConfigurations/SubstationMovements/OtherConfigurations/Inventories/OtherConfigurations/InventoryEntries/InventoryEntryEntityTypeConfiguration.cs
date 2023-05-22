using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;

namespace SubstationTracker.Persistence.EntityConfigurations.Substations.OtherEntityConfigurations.SubstationMovements.OtherConfigurations.Inventories.OtherConfigurations.InventoryEntries;

public class InventoryEntryEntityTypeConfiguration : IEntityTypeConfiguration<InventoryEntry>
{
    public void Configure(EntityTypeBuilder<InventoryEntry> builder)
    {
        builder.HasKey(_inventoryEntry => _inventoryEntry.Id);

        builder.Property(_inventoryEntry => _inventoryEntry.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_inventoryEntry => _inventoryEntry.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.HasQueryFilter(_inventoryEntry => _inventoryEntry.Inventory!.SubstationMovement!.IsDeleted == false);

        builder.HasOne(_inventoryEntry => _inventoryEntry.Inventory)
            .WithOne(_inventory => _inventory.InventoryEntry)
            .HasForeignKey<InventoryEntry>(_inventoryEntry => _inventoryEntry.Id);

        builder.HasOne(_inventoryEntry => _inventoryEntry.Audit)
            .WithOne(_audit => _audit.InventoryEntry)
            .HasForeignKey<InventoryEntry>(_inventoryEntry => _inventoryEntry.AuditId);
    }
}