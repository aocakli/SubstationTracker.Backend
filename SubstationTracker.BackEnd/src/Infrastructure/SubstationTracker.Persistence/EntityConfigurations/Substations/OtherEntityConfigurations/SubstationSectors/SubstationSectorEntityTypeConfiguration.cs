using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationSectors;

namespace SubstationTracker.Persistence.EntityConfigurations.Substations.OtherEntityConfigurations.SubstationSectors;

public class SubstationSectorEntityTypeConfiguration : IEntityTypeConfiguration<SubstationSector>
{
    public void Configure(EntityTypeBuilder<SubstationSector> builder)
    {
        builder.HasKey(_substationSector => _substationSector.Id);

        builder.Property(_substationSector => _substationSector.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_substationSector => _substationSector.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_substationSector => _substationSector.SubstationId)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_substationSector => _substationSector.SectorId)
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(_substationSector => _substationSector.IsDeleted)
            .HasColumnOrder(4)
            .IsRequired();

        builder.HasQueryFilter(_substationSector => _substationSector.IsDeleted == false &&
                                                    _substationSector.Substation!.IsDeleted == false &&
                                                    _substationSector.Sector!.IsDeleted == false);

        builder.HasOne(_substationSector => _substationSector.Audit)
            .WithOne(_audit => _audit.SubstationSector)
            .HasForeignKey<SubstationSector>(_substationSector => _substationSector.AuditId);

        builder.HasOne(_substationSector => _substationSector.Substation)
            .WithMany(_substation => _substation.SubstationSectors)
            .HasForeignKey(_substationSector => _substationSector.SubstationId);

        builder.HasOne(_substationSector => _substationSector.Sector)
            .WithMany(_sector => _sector.SubstationSectors)
            .HasForeignKey(_substationSector => _substationSector.SectorId);
    }
}