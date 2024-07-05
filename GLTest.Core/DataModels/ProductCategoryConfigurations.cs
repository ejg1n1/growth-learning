using GLTest.Core.Domains.ProductCategory;
using GLTest.Core.Domains.ProductCategoryList;
using GLTest.Core.Domains.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GLTest.Core.DataModels;

public class ProductCategoryConfigurations : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProductId).ValueGeneratedNever();
        builder.Property(x => x.CategoryId).ValueGeneratedNever();
    }
}
