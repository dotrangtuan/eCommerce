using eCommerce.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infrastructure.Persistence;

public class ProductConfiguration : IEntityTypeConfiguration<Domain.Entities.Product>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Product> builder)
    {
        builder.HasQueryFilter(p => !p.IsDeleted);

        builder.ToTable(TableName.Product);

        builder.HasKey(p => p.Id);

        builder.Property(p => p.ProductName).IsRequired().HasMaxLength(50);

        builder.Property(p => p.UnitPrice).IsRequired();
        
        builder.Property(p => p.UnitsInStock).IsRequired();
        
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}