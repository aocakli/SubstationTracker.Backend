using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Users._Bases;

namespace SubstationTracker.Persistence.EntityConfigurations.Users;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(_user => _user.Id);

        builder.Property(_user => _user.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_user => _user.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_user => _user.Email)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_user => _user.Password)
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(_user => _user.Name)
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(_user => _user.Surname)
            .HasColumnOrder(5)
            .IsRequired();

        builder.Property(_user => _user.IsDeleted)
            .HasColumnOrder(6)
            .IsRequired();

        builder.HasQueryFilter(_user => _user.IsDeleted == false);

        builder.HasOne(_user => _user.Audit)
            .WithOne(_audit => _audit.User)
            .HasForeignKey<User>(_user => _user.AuditId);
    }
}