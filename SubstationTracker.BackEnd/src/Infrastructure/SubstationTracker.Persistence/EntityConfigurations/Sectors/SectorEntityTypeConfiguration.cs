using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Sectors;

namespace SubstationTracker.Persistence.EntityConfigurations.Sectors;

public class SectorEntityTypeConfiguration : IEntityTypeConfiguration<Sector>
{
    public void Configure(EntityTypeBuilder<Sector> builder)
    {
        builder.HasKey(_sector => _sector.Id);

        builder.Property(_sector => _sector.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_sector => _sector.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_sector => _sector.Name)
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.Property(_sector => _sector.Description)
            .HasColumnOrder(3)
            .IsRequired(false);

        builder.Property(_sector => _sector.IsDeleted)
            .HasColumnOrder(4)
            .IsRequired();

        builder.HasQueryFilter(_sector => _sector.IsDeleted == false);

        builder.HasOne(_sector => _sector.Audit)
            .WithOne(_audit => _audit.Sector)
            .HasForeignKey<Sector>(_sector => _sector.AuditId);
    }
}