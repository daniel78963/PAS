﻿using AutoMapper;
using PAS.Application.Dto;
using PAS.Application.Interfaces;
using PAS.Domain.Interfaces;

namespace PAS.Application.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryDomain productCategoryDomain;
        private readonly IMapper mapper;

        public ProductCategoryService(IProductCategoryDomain productCategoryDomain, IMapper mapper)
        {
            this.productCategoryDomain = productCategoryDomain;
            this.mapper = mapper;
        }

        public Response<IEnumerable<ProductCategoryDto>> GetProductsCategories()
        {
            var response = new Response<IEnumerable<ProductCategoryDto>>();
            try
            {
                var categories = productCategoryDomain.GetProductsCategories();
                response.Data = mapper.Map<IEnumerable<ProductCategoryDto>>(categories);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<ProductCategoryDto>> GetProductsCategories(string parameters)
        {
            var response = new Response<IEnumerable<ProductCategoryDto>>();
            try
            {
                var categories = productCategoryDomain.GetProductsCategories(parameters);
                response.Data = mapper.Map<IEnumerable<ProductCategoryDto>>(categories);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}