using PAS.Domain.Entities;
using PAS.Infrastructure.Interfaces;

namespace PAS.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IDataContext dataContext;

        public ProductCategoryRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<ProductCategory> GetProductsCategories()
        {
            return dataContext.ProductCategories;
        }

        public IEnumerable<ProductCategory> GetProductsCategories(string parameters)
        {
            return dataContext.ProductCategories;
        }
    }
}
