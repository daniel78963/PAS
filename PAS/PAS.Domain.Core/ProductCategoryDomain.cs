﻿using PAS.Application.QueryParameters;
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

        public ProductCategoryDomain(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductCategory> GetProductsCategories()
        {
            //return productCategoryRepository.GetProductsCategories();
            return unitOfWork.ProductCategoriesRepository.GetProductsCategories();
        }

        public IEnumerable<ProductCategory> GetProductsCategoriesFilters(ProductCategoryParameters parameters)
        {
            return unitOfWork.ProductCategoriesRepository.GetProductsCategoriesFilters(parameters);
        }
    }
}
