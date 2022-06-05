using PAS.Application.QueryParameters;
using PAS.Domain.Entities;

namespace PAS.Domain.Interfaces
{
    public interface IProductCategoryDomain
    {
        Task<ProductCategory> GetByIdAsync(object id);
        //Task<ProductCategory> GetByNameAsync(string name);
        Task<bool> AddAsync(ProductCategory productCategory);
        Task<bool> UpdateAsync(ProductCategory productCategory);
        IEnumerable<ProductCategory> GetProductsCategories();
        IEnumerable<ProductCategory> GetProductsCategoriesFilters(ProductCategoryParameters parameters);
    }
}
