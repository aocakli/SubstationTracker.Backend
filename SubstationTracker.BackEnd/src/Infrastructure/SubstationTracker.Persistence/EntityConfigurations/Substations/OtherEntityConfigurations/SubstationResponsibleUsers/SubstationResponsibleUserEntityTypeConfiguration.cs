using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationResponsibleUsers;

namespace SubstationTracker.Persistence.EntityConfigurations.Substations.OtherEntityConfigurations.SubstationResponsibleUsers;

public class SubstationResponsibleUserEntityTypeConfiguration : IEntityTypeConfiguration<SubstationResponsibleUser>
{
    public void Configure(EntityTypeBuilder<SubstationResponsibleUser> builder)
    {
        builder.HasKey(_substationResponsibleUser => _substationResponsibleUser.Id);

        builder.Property(_substationResponsibleUser => _substationResponsibleUser.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_substationResponsibleUser => _substationResponsibleUser.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_substationResponsibleUser => _substationResponsibleUser.SubstationId)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_substationResponsibleUser => _substationResponsibleUser.ResponsibleUserId)
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(_substationResponsibleUser => _substationResponsibleUser.IsDeleted)
            .HasColumnOrder(4)
            .IsRequired();

        builder.HasQueryFilter(_substationResponsibleUser => _substationResponsibleUser.IsDeleted == false &&
                                                             _substationResponsibleUser.Substation!.IsDeleted ==
                                                             false &&
                                                             _substationResponsibleUser.ResponsibleUser!.IsDeleted ==
                                                             false);

        builder.HasOne(_substationResponsibleUser => _substationResponsibleUser.Audit)
            .WithOne(_audit => _audit.SubstationResponsibleUser)
            .HasForeignKey<SubstationResponsibleUser>(_substationResponsibleUser => _substationResponsibleUser.AuditId);

        builder.HasOne(_substationResponsibleUser => _substationResponsibleUser.Substation)
            .WithMany(_substation => _substation.SubstationResponsibleUsers)
            .HasForeignKey(_substationResponsibleUser => _substationResponsibleUser.SubstationId);

        builder.HasOne(_substationResponsibleUser => _substationResponsibleUser.ResponsibleUser)
            .WithMany(_responsibleUser => _responsibleUser.SubstationResponsibleUsers)
            .HasForeignKey(_substationResponsibleUser => _substationResponsibleUser.ResponsibleUserId);
    }
}