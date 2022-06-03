using PAS.Application.QueryParameters;
using PAS.Domain.Entities;
using PAS.Domain.Interfaces;
using PAS.Infrastructure.Interfaces;

namespace PAS.Domain.Core
{
    public class ProductCategoryDomain : IProductCategoryDomain
    {
        //private readonly IProductCategoryRepository productCategoryRepository;

        //public ProductCategoryDomain(IProductCategoryRepository productCategoryRepository)
        //{
        //    this.productCategoryRepository = productCategoryRepository;
        //}
        private readonly IUnitOfWork unitOfWork;

        public ProductCategoryDomain(IUnitOfWork unitOfWork, IProductCategoryRepository productCategoryRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<ProductCategory> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetProductsCategories()
        {
            //return productCategoryRepository.GetProductsCategories();
            return unitOfWork.ProductCategoriesRepository.GetProductsCategories();
        }

        public IEnumerable<ProductCategory> GetProductsCategoriesFilters(ProductCategoryParameters parameters)
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.NameCategory = "Nuevo ";
            unitOfWork.ProductCategoriesRepository.Add(productCategory);
            unitOfWork.Complete();

            return unitOfWork.ProductCategoriesRepository.GetProductsCategoriesFilters(parameters);
        }
    }
}
