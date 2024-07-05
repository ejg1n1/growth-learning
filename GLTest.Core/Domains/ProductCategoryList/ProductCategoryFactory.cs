using GLTest.Core.Common;
using GLTest.Core.Domains.Categories;
using GLTest.Core.Domains.Products;

namespace GLTest.Core.Domains.ProductCategory;

public class ProductCategoryFactory
{
    public class ProductFactory : ProductCategoryList.ProductCategory, IProductCategoryFactory
    {
        public ResultModel<ProductCategoryList.ProductCategory> CreateInstance(Product product, Category cateogry)
        {
            if (product != null && cateogry != null)
            {
                var result = Create(product, cateogry);
                return new ResultModel<ProductCategoryList.ProductCategory>(result);
            }
            
            return new 
                ResultModel<ProductCategoryList.ProductCategory>(false, 
                    "Both the product and category are required"); 
        }
    }
}