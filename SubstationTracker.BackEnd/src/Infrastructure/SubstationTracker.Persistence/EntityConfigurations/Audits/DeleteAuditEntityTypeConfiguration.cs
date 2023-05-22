using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Abstractions.Audits;

namespace SubstationTracker.Persistence.EntityConfigurations.Audits;

public class DeleteAuditEntityTypeConfiguration : IEntityTypeConfiguration<DeleteAudit>
{
    public void Configure(EntityTypeBuilder<DeleteAudit> builder)
    {
        builder.HasKey(_deleteAudit => _deleteAudit.Id);

        builder.Property(_deleteAudit => _deleteAudit.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_deleteAudit => _deleteAudit.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_deleteAudit => _deleteAudit.DeletedById)
            .HasColumnOrder(2)
            .IsRequired(false);

        builder.Property(_deleteAudit => _deleteAudit.DeletedDate)
            .HasColumnOrder(3)
            .IsRequired();

        builder.HasOne(_deleteAudit => _deleteAudit.Audit)
            .WithOne(_audit => _audit.DeleteAudit)
            .HasForeignKey<DeleteAudit>(_deleteAudit => _deleteAudit.AuditId);

        builder.HasOne(_deleteAudit => _deleteAudit.DeletedUser)
            .WithMany(_deletedUser => _deletedUser.DeleteAudits)
            .HasForeignKey(_deleteAudit => _deleteAudit.DeletedById);
    }
}