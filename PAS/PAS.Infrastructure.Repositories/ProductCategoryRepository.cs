using PAS.Domain.Entities;
using PAS.Infrastructure.Data;
using PAS.Infrastructure.Interfaces;

namespace PAS.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly DataContext dataContext;

        public ProductCategoryRepository(DataContext dataContext)
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
