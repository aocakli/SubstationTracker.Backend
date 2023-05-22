using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;

namespace SubstationTracker.Persistence.EntityConfigurations.Substations.OtherEntityConfigurations.SubstationMovements.OtherConfigurations.Inventories._Bases;

public class InventoryEntityTypeConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(_inventory => _inventory.Id);

        builder.Property(_inventory => _inventory.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_inventory => _inventory.ProductId)
            .HasColumnOrder(1)
            .IsRequired();
        
        builder.Property(_inventory => _inventory.SubstationMovementId)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_inventory => _inventory.AuditId)
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(_inventory => _inventory.ProductName)
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(_inventory => _inventory.Quantity)
            .HasColumnOrder(5)
            .IsRequired();
        
        builder.Property(_inventory => _inventory.TotalPrice)
            .HasColumnOrder(6)
            .IsRequired();

        builder.Property(_inventory => _inventory.Unit)
            .HasColumnOrder(7)
            .IsRequired();

        builder.Property(_inventory => _inventory.Description)
            .HasColumnOrder(8)
            .IsRequired(false);
        
        builder.HasQueryFilter(_inventory => _inventory.SubstationMovement!.IsDeleted == false);

        builder.HasOne(_inventory => _inventory.Product)
            .WithMany(_product => _product.Inventories)
            .HasForeignKey(_inventory => _inventory.ProductId);

        builder.HasOne(_inventory => _inventory.SubstationMovement)
            .WithOne(_substationMovement => _substationMovement.Inventory)
            .HasForeignKey<Inventory>(_inventory => _inventory.SubstationMovementId);
        
        builder.HasOne(_inventory => _inventory.Audit)
            .WithOne(_audit => _audit.Inventory)
            .HasForeignKey<Inventory>(_inventory => _inventory.AuditId);
    }
}