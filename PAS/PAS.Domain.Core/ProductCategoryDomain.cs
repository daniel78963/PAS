using PAS.Domain.Entities;
using PAS.Domain.Interfaces;
using PAS.Infrastructure.Interfaces;

namespace PAS.Domain.Core
{
    public class ProductCategoryDomain : IProductCategoryDomain
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryDomain(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public IEnumerable<ProductCategory> GetCategories()
        {
            return productCategoryRepository.GetProductsCategories();
        }

        public IEnumerable<ProductCategory> GetProductsCategories(string parameters)
        {
            return productCategoryRepository.GetProductsCategories(parameters);
        }
    }
}
