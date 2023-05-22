using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs.Enums;

namespace SubstationTracker.Persistence.EntityConfigurations.Users.OtherEntityConfigurations;

public class UserLogEntityTypeConfiguration : IEntityTypeConfiguration<UserLog>
{
    public void Configure(EntityTypeBuilder<UserLog> builder)
    {
        builder.HasKey(_userLog => _userLog.Id);

        builder.Property(_userLog => _userLog.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_userLog => _userLog.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_userLog => _userLog.UserId)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_userLog => _userLog.Type)
            .HasColumnOrder(3)
            .HasDefaultValue(LogType.Unknown)
            .IsRequired();

        builder.Property(_userLog => _userLog.Parameters)
            .HasColumnOrder(4)
            .IsRequired(false);

        builder.Property(_userLog => _userLog.IsSuccess)
            .HasColumnOrder(5)
            .HasDefaultValue(false)
            .IsRequired();
        
        builder.HasOne(_userLog => _userLog.Audit)
            .WithOne(_audit => _audit.UserLog)
            .HasForeignKey<UserLog>(_userLog => _userLog.AuditId);
    }
}