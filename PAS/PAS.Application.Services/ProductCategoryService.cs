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

                if (entity == null)
                {
                    response.IsSuccess = true;
                    response.StatusCode = 200;
                    response.Message = "No data";
                    response.Code = "1202";
                    return response;
                }

                response.Data = mapper.Map<ProductCategoryDto>(entity);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.StatusCode = 200;
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

        public async Task<Response<IEnumerable<Error>>> ValidateObjetc(ProductDto productDto)
        {
            Response<IEnumerable<Error>> response = new Response<IEnumerable<Error>>();
            List<Error> errores = new List<Error>();

            if (string.IsNullOrEmpty(productDto.Name))
            {
                response.IsSuccess = false;
                Error error = new Error()
                {
                    Code = "1410",
                    Message = "Field Name is required"
                };
                errores.Add(error);
            }

            if (productDto.Name != null && productDto.Name.Length < 2)
            {
                Error error = new Error()
                {
                    Code = "1416",
                    Message = "Field Name is not valid lenght"
                };
                errores.Add(error);
            }

            if (errores.Count > 1)
            {
                response.IsSuccess = false;
                response.StatusCode = 400;
                response.Message = "Multiple errors";
                response.Code = "1440";
                response.Data = errores;
                return response;
            }

            if (errores.Any())
            {
                response.IsSuccess = false;
                response.StatusCode = 400;
                response.Message = errores.FirstOrDefault().Message;
                response.Code = errores.FirstOrDefault().Code;
                return response;
            }

            response.IsSuccess = true;
            return response;
        }
    }
}
