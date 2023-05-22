using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Abstractions.Audits;

namespace SubstationTracker.Persistence.EntityConfigurations.Audits;

public class CreateAuditEntityTypeConfiguration : IEntityTypeConfiguration<CreateAudit>
{
    public void Configure(EntityTypeBuilder<CreateAudit> builder)
    {
        builder.HasKey(_createAudit => _createAudit.Id);

        builder.Property(_createAudit => _createAudit.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_createAudit => _createAudit.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_createAudit => _createAudit.CreatedById)
            .HasColumnOrder(2)
            .IsRequired(false);

        builder.Property(_createAudit => _createAudit.CreatedDate)
            .HasColumnOrder(3)
            .IsRequired();

        builder.HasOne(_createAudit => _createAudit.Audit)
            .WithOne(_audit => _audit.CreateAudit)
            .HasForeignKey<CreateAudit>(_createAudit => _createAudit.AuditId);

        builder.HasOne(_createAudit => _createAudit.CreatedUser)
            .WithMany(_createdUser => _createdUser.CreateAudits)
            .HasForeignKey(_createAudit => _createAudit.CreatedById);
    }
}