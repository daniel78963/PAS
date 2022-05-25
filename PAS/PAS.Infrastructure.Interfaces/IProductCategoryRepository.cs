using PAS.Application.QueryParameters;
using PAS.Domain.Entities;

namespace PAS.Infrastructure.Interfaces
{
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetProductsCategories();
        IEnumerable<ProductCategory> GetProductsCategoriesFilters(ProductCategoryParameters parameters);
    }
}
