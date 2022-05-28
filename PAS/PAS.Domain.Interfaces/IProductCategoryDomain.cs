using PAS.Application.QueryParameters;
using PAS.Domain.Entities;

namespace PAS.Domain.Interfaces
{
    public interface IProductCategoryDomain 
    {
        public IEnumerable<ProductCategory> GetProductsCategories();

        public IEnumerable<ProductCategory> GetProductsCategoriesFilters(ProductCategoryParameters parameters);
    }
}
