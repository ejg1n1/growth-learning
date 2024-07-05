using System.Linq.Expressions;
using GLTest.Core.Contexts;
using GLTest.Core.Domains.ProductCategory;
using GLTest.Core.Domains.ProductCategoryList;
using Microsoft.EntityFrameworkCore.Query;

namespace GLTest.Core.Repositories.ProductCategories;

public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoriesRepository
{
    public ProductCategoryRepository(AppDbContext context) : base(context)
    {
    }
}