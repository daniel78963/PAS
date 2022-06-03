using AutoMapper;
using PAS.Application.Dto;
using PAS.Application.Interfaces;
using PAS.Application.QueryParameters;
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

        public async Task<Response<ProductCategoryDto>> GetByIdAsync(object id)
        {
            var response = new Response<ProductCategoryDto>();
            try
            {
                var entity = await productCategoryDomain.GetByIdAsync(id);
                response.Data = mapper.Map<ProductCategoryDto>(entity);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                    response.Code = "1201";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
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
                    response.Code = "1201";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<ProductCategoryDto>> GetProductsCategoriesFilters(ProductCategoryParameters parameters)
        {
            var response = new Response<IEnumerable<ProductCategoryDto>>();
            try
            {
                var categories = productCategoryDomain.GetProductsCategoriesFilters(parameters);
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
