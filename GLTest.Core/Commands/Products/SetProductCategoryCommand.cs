using GLTest.Core.Common;
using GLTest.Core.Domains.ProductCategoryList;
using GLTest.Core.Repositories.Categories;
using GLTest.Core.Repositories.ProductCategories;
using GLTest.Core.Repositories.Products;

namespace GLTest.Core.Commands.Products
{
    public class SetProductCategoryCommand : ISetProductCategoryCommand
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductCategoriesRepository _productCategoriesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetProductCategoryCommand(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IProductCategoriesRepository productCategoriesRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productCategoriesRepository = productCategoriesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResult<bool>> ExecuteAsync(Guid productId, List<Guid> categoryIdList)
        {
            var product = await _productRepository.FirstOrDefaultAsync(a => a.ProductId == productId);
            if (product == null)
                return new CommandResult<bool>("Set_Product_Category_Product_NotFound", "Product not found. ");

            //Give the db some headroom and not hit it inside the for loop
            var categoriesList = await _categoryRepository.GetAllAsync();

            foreach (var categoryId in categoryIdList)
            {
                var category = categoriesList.FirstOrDefault(a => a.CategoryId == categoryId);
                if (category == null)
                    return new CommandResult<bool>("Set_Product_Category_Category_NotFound", "Category not found. ");

                var productCategory = new ProductCategory()
                {
                    Product = product,
                    Category = category
                };
                
                _productCategoriesRepository.Add(productCategory);
            }

            await _unitOfWork.CommitAsync();

            return new CommandResult<bool>(true);
        }
    }
}
