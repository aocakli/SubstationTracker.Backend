using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;

namespace SubstationTracker.Persistence.EntityConfigurations.Users.OtherEntityConfigurations;

public class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(_userRole => _userRole.Id);

        builder.Property(_userRole => _userRole.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_userRole => _userRole.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_userRole => _userRole.UserId)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_userRole => _userRole.Role)
            .HasColumnOrder(3)
            .IsRequired()
            .HasDefaultValue(UserRoleTypes.Unknown);

        builder.Property(_userRole => _userRole.IsDeleted)
            .HasColumnOrder(4)
            .IsRequired()
            .HasDefaultValue(UserRoleTypes.Unknown);

        builder.HasQueryFilter(_userRole => _userRole.IsDeleted == false && _userRole.User.IsDeleted == false);

        builder.HasOne(_userRole => _userRole.User)
            .WithMany(_user => _user.UserRoles)
            .HasForeignKey(_userRole => _userRole.UserId);

        builder.HasOne(_userRole => _userRole.Audit)
            .WithOne(_role => _role.UserRole)
            .HasForeignKey<UserRole>(_userRole => _userRole.AuditId);
    }
}