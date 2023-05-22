using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements;

namespace SubstationTracker.Persistence.EntityConfigurations.Substations.OtherEntityConfigurations.
    SubstationMovements;

public class SubstationMovementEntityTypeConfiguration : IEntityTypeConfiguration<SubstationMovement>
{
    public void Configure(EntityTypeBuilder<SubstationMovement> builder)
    {
        builder.HasKey(_substationMovement => _substationMovement.Id);

        builder.Property(_substationMovement => _substationMovement.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_substationMovement => _substationMovement.SubstationId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_substationMovement => _substationMovement.AuditId)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_substationMovement => _substationMovement.ProcessTime)
            .HasColumnOrder(3)
            .IsRequired();
        
        builder.Property(_substationMovement => _substationMovement.IsDeleted)
            .HasColumnOrder(4)
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasQueryFilter(_substationMovement => _substationMovement.IsDeleted == false);

        builder.HasOne(_substationMovement => _substationMovement.Substation)
            .WithMany(_substation => _substation.SubstationMovements)
            .HasForeignKey(_substationMovement => _substationMovement.SubstationId);

        builder.HasOne(_substationMovement => _substationMovement.Audit)
            .WithOne(_substation => _substation.SubstationMovement)
            .HasForeignKey<SubstationMovement>(_substationMovement => _substationMovement.AuditId);
    }
}