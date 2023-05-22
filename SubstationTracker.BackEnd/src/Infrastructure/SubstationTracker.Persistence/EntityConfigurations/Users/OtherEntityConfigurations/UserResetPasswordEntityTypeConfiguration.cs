using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserResetPasswords;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserTokens;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.Enums;

namespace SubstationTracker.Persistence.EntityConfigurations.Users.OtherEntityConfigurations;

public class UserResetPasswordEntityTypeConfiguration : IEntityTypeConfiguration<UserResetPassword>
{
    public void Configure(EntityTypeBuilder<UserResetPassword> builder)
    {
        builder.HasKey(_userResetPassword => _userResetPassword.Id);

        builder.Property(_userResetPassword => _userResetPassword.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_userResetPassword => _userResetPassword.UserId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_userResetPassword => _userResetPassword.Code)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_userResetPassword => _userResetPassword.ExpiryDate)
            .HasColumnOrder(3)
            .IsRequired();

        builder.HasQueryFilter(_userResetPassword => _userResetPassword.User.IsDeleted == false);

        builder.HasOne(_userResetPassword => _userResetPassword.User)
            .WithOne(_user => _user.ResetPassword)
            .HasForeignKey<UserResetPassword>(_userResetPassword => _userResetPassword.UserId);
    }
}