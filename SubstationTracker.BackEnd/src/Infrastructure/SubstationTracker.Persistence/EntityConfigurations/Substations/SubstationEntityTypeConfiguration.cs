using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Sectors;
using SubstationTracker.Domain.Concrete.Substations;
using SubstationTracker.Domain.Concrete.Substations._Bases;

namespace SubstationTracker.Persistence.EntityConfigurations.Substations;

public class SubstationEntityTypeConfiguration : IEntityTypeConfiguration<Substation>
{
    public void Configure(EntityTypeBuilder<Substation> builder)
    {
        builder.HasKey(_substation => _substation.Id);

        builder.Property(_substation => _substation.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_substation => _substation.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_substation => _substation.Name)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_substation => _substation.PhoneNumber)
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(_substation => _substation.Address)
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(_substation => _substation.Description)
            .HasColumnOrder(5)
            .IsRequired()
            .HasDefaultValue(string.Empty);

        builder.Property(_substation => _substation.PhotoPath)
            .HasColumnOrder(6)
            .IsRequired()
            .HasDefaultValue(string.Empty);

        builder.Property(_substation => _substation.IsDeleted)
            .HasColumnOrder(7)
            .IsRequired();

        builder.HasQueryFilter(_substation => _substation.IsDeleted == false);

        builder.HasOne(_substation => _substation.Audit)
            .WithOne(_audit => _audit.Substation)
            .HasForeignKey<Substation>(_substation => _substation.AuditId);
    }
}