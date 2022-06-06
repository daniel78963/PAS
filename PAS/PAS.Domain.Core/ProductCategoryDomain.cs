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

        public async Task<ProductCategory> GetByIdAsync(object id)
        {
            return await unitOfWork.ProductCategoriesRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddAsync(ProductCategory productCategory)
        {
            await unitOfWork.ProductCategoriesRepository.AddAsync(productCategory);
            unitOfWork.Complete();
            return true;
        }

        public async Task<bool> UpdateAsync(ProductCategory productCategory)
        {
            bool valid = await unitOfWork.ProductCategoriesRepository.UpdateAsync(productCategory, productCategory.Id);
            if (!valid)
            {
                return false;
            }
            unitOfWork.Complete();
            return true;
        }

        public async Task<bool> DeleteAync(ProductCategory productCategory)
        {
            bool valid = await unitOfWork.ProductCategoriesRepository.DeleteAsync(productCategory.Id);
            if (!valid)
            {
                return false;
            }
            unitOfWork.Complete();
            return true;
        }

        public IEnumerable<ProductCategory> GetProductsCategories()
        {
            //return productCategoryRepository.GetProductsCategories();
            return unitOfWork.ProductCategoriesRepository.GetProductsCategories();
        }

        public IEnumerable<ProductCategory> GetProductsCategoriesFilters(ProductCategoryParameters parameters)
        {
            //ProductCategory productCategory = new ProductCategory();
            //productCategory.NameCategory = "Nuevo ";
            //unitOfWork.ProductCategoriesRepository.Add(productCategory);
            //unitOfWork.Complete();

            return unitOfWork.ProductCategoriesRepository.GetProductsCategoriesFilters(parameters);
        }
    }
}
