using GLTest.Core.Domains.Categories;
using GLTest.Core.Domains.Products;

namespace GLTest.Core.Domains.ProductCategoryList;

public class ProductCategory
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public static ProductCategory Create(Product product, Category category)
    {
        return new ProductCategory
        {
            ProductId = product.ProductId,
            Product = product,
            CategoryId = category.CategoryId,
            Category = category
        };
    }
}