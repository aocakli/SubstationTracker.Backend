using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserTokens;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.Enums;

namespace SubstationTracker.Persistence.EntityConfigurations.Users.OtherEntityConfigurations;

public class UserTokenEntityTypeConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.HasKey(_userToken => _userToken.Id);

        builder.Property(_userToken => _userToken.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_userToken => _userToken.UserId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_userToken => _userToken.Token)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_userToken => _userToken.ExpiryDate)
            .HasColumnOrder(3)
            .IsRequired();

        builder.HasQueryFilter(_userToken => _userToken.User.IsDeleted == false);

        builder.HasOne(_userToken => _userToken.User)
            .WithOne(_user => _user.RefreshToken)
            .HasForeignKey<UserToken>(_userToken => _userToken.UserId);
    }
}