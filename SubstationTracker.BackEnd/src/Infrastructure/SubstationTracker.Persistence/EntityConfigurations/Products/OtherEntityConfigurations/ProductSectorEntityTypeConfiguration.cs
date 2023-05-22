using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubstationTracker.Domain.Concrete.Products;
using SubstationTracker.Domain.Concrete.Products.OtherDomains;

namespace SubstationTracker.Persistence.EntityConfigurations.Products.OtherEntityConfigurations;

public class ProductSectorEntityTypeConfiguration : IEntityTypeConfiguration<ProductSector>
{
    public void Configure(EntityTypeBuilder<ProductSector> builder)
    {
        builder.HasKey(_productSector => _productSector.Id);

        builder.Property(_productSector => _productSector.Id)
            .HasColumnOrder(0)
            .IsRequired();

        builder.Property(_productSector => _productSector.AuditId)
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(_productSector => _productSector.ProductId)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(_productSector => _productSector.SectorId)
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(_productSector => _productSector.IsDeleted)
            .HasColumnOrder(4)
            .IsRequired();

        builder.HasQueryFilter(_productSector => _productSector.IsDeleted == false &&
                                                 _productSector.Sector!.IsDeleted == false &&
                                                 _productSector.Product!.IsDeleted == false);

        builder.HasOne(_productSector => _productSector.Audit)
            .WithOne(_audit => _audit.ProductSector)
            .HasForeignKey<ProductSector>(_productSector => _productSector.AuditId);

        builder.HasOne(_productSector => _productSector.Product)
            .WithMany(_product => _product.ProductSectors)
            .HasForeignKey(_productSector => _productSector.ProductId);

        builder.HasOne(_productSector => _productSector.Sector)
            .WithMany(_sector => _sector.ProductSectors)
            .HasForeignKey(_productSector => _productSector.SectorId);
    }
}