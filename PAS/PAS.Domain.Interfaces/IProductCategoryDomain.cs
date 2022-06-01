using PAS.Application.QueryParameters;
using PAS.Domain.Entities;

namespace PAS.Domain.Interfaces
{
    public interface IProductCategoryDomain : IGenericDomain<ProductCategory>  
    {
        public IEnumerable<ProductCategory> GetProductsCategories();

        public IEnumerable<ProductCategory> GetProductsCategoriesFilters(ProductCategoryParameters parameters);
    }
}
