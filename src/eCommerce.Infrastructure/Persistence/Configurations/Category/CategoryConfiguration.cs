using eCommerce.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infrastructure.Persistence;

public class CategoryConfiguration : IEntityTypeConfiguration<Domain.Entities.Category>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Category> builder)
    {
        builder.HasQueryFilter(c => !c.IsDeleted);

        builder.ToTable(TableName.Category);

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
        
    }
}