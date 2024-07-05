using GLTest.Core.Domains.Categories;
using GLTest.Core.Domains.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GLTest.Core.DataModels
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductId).ValueGeneratedNever();
            
            builder.HasMany(pc => pc.ProductCategories)
                .WithOne(c => c.Product)
                .HasForeignKey(ur => ur.ProductId).IsRequired();
        }
    }
}
