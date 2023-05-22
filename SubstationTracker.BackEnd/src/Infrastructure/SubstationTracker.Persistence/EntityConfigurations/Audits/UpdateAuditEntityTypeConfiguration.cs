using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Abstractions.Audits;

namespace SubstationTracker.Persistence.EntityConfigurations.Audits;

public class UpdateAuditEntityTypeConfiguration : IEntityTypeConfiguration<UpdateAudit>
{
    public void Configure(EntityTypeBuilder<UpdateAudit> builder)
    {
        builder.HasKey(_updateAudit => _updateAudit.Id);

        builder.Property(_updateAudit => _updateAudit.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_updateAudit => _updateAudit.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_updateAudit => _updateAudit.UpdatedById)
            .HasColumnOrder(2)
            .IsRequired(false);

        builder.Property(_updateAudit => _updateAudit.UpdatedDate)
            .HasColumnOrder(3)
            .IsRequired();

        builder.HasOne(_updateAudit => _updateAudit.Audit)
            .WithMany(_audit => _audit.UpdateAudits)
            .HasForeignKey(_updateAudit => _updateAudit.AuditId);

        builder.HasOne(_updateAudit => _updateAudit.UpdatedUser)
            .WithMany(_createdUser => _createdUser.UpdateAudits)
            .HasForeignKey(_updateAudit => _updateAudit.UpdatedById);
    }
}