using GLTest.Core.Common;
using GLTest.Core.Domains.Categories;
using GLTest.Core.Domains.Products;

namespace GLTest.Core.Domains.ProductCategory;

public interface IProductCategoryFactory
{
    public ResultModel<ProductCategoryList.ProductCategory> CreateInstance(Product product, Category category);
}