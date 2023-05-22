using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Products;

namespace SubstationTracker.Persistence.EntityConfigurations.Products;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(_product => _product.Id);

        builder.Property(_product => _product.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_product => _product.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_product => _product.Name)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_product => _product.PhotoPath)
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(_product => _product.Unit)
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(_product => _product.IsDeleted)
            .HasColumnOrder(5)
            .IsRequired();

        builder.HasQueryFilter(_product => _product.IsDeleted == false);

        builder.HasOne(_product => _product.Audit)
            .WithOne(_audit => _audit.Product)
            .HasForeignKey<Product>(_product => _product.AuditId);
    }
}