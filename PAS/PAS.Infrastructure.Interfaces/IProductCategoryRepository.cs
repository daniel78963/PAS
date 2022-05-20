using PAS.Domain.Entities;

namespace PAS.Infrastructure.Interfaces
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetProductsCategories();
        IEnumerable<ProductCategory> GetProductsCategories(string parameters);
    }
}
