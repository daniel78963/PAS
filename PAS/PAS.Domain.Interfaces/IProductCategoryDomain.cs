using PAS.Application.QueryParameters;
using PAS.Domain.Entities;

namespace PAS.Domain.Interfaces
{
    public interface IProductCategoryDomain
    {
        Task<ProductCategory> GetByIdAsync(object id);
        IEnumerable<ProductCategory> GetProductsCategories();
        IEnumerable<ProductCategory> GetProductsCategoriesFilters(ProductCategoryParameters parameters);
    }
}
