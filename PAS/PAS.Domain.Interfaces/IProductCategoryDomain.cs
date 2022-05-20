using PAS.Domain.Entities;

namespace PAS.Domain.Interfaces
{
    public interface IProductCategoryDomain
    {
        public IEnumerable<ProductCategory> GetCategories();

        public IEnumerable<ProductCategory> GetProductsCategories(string parameters);
    }
}
