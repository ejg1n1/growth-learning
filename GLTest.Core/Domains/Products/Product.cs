using GLTest.Core.Domains.Categories;

namespace GLTest.Core.Domains.Products
{
    public class Product
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        
        public ICollection<ProductCategoryList.ProductCategory> ProductCategories { get; private set; } 

        protected Product() { }

        protected Product Create(string name)
        {
            return new Product
            {
                ProductName = name
            };
        }
        
    }
}
