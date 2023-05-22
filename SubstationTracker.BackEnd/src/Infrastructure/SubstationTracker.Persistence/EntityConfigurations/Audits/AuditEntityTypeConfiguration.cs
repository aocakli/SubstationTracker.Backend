using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Abstractions.Audits;

namespace SubstationTracker.Persistence.EntityConfigurations.Audits;

public class AuditEntityTypeConfiguration : IEntityTypeConfiguration<Audit>
{
    public void Configure(EntityTypeBuilder<Audit> builder)
    {
        builder.HasKey(_audit => _audit.Id);

        builder.Property(_audit => _audit.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_audit => _audit.Table)
            .HasColumnOrder(1)
            .IsRequired();
    }
}