using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.Enums;

namespace SubstationTracker.Persistence.EntityConfigurations.Users.OtherEntityConfigurations;

public class UserVerificationEntityTypeConfiguration : IEntityTypeConfiguration<UserVerification>
{
    public void Configure(EntityTypeBuilder<UserVerification> builder)
    {
        builder.HasKey(_userVerification => _userVerification.Id);

        builder.Property(_userVerification => _userVerification.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_userVerification => _userVerification.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_userVerification => _userVerification.UserId)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_userVerification => _userVerification.VerificationType)
            .HasColumnOrder(3)
            .IsRequired()
            .HasDefaultValue(UserVerificationType.Unknown);

        builder.Property(_userVerification => _userVerification.Code)
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(_userVerification => _userVerification.IsUsed)
            .HasColumnOrder(5)
            .IsRequired();

        builder.Property(_userVerification => _userVerification.ExpiryDate)
            .HasColumnOrder(6)
            .IsRequired();

        builder.Property(_userVerification => _userVerification.IsDeleted)
            .HasColumnOrder(7)
            .IsRequired();

        builder.HasQueryFilter(_userVerification =>
            _userVerification.IsDeleted == false && _userVerification.User.IsDeleted == false);

        builder.HasOne(_userVerification => _userVerification.User)
            .WithMany(_user => _user.UserVerifications)
            .HasForeignKey(_userVerification => _userVerification.UserId);

        builder.HasOne(_userVerification => _userVerification.Audit)
            .WithOne(_audit => _audit.UserVerification)
            .HasForeignKey<UserVerification>(_userVerification => _userVerification.AuditId);
    }
}