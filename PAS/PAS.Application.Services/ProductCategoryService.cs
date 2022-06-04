using AutoMapper;
using PAS.Application.Dto;
using PAS.Application.Interfaces;
using PAS.Application.QueryParameters;
using PAS.Domain.Entities;
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

        //public async Task<Response<ProductCategoryDto>> GetByIdAsync(object id)
        public async Task<Response> GetByIdAsync(object id)
        {
            //var response = new Response<ProductCategoryDto>();
            var response = new Response();
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

                var data = mapper.Map<ProductCategoryDto>(entity);
                if (data != null)
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

        public async Task<Response> AddAsync(ProductCategoryDto dto)
        { 
            var response = new Response();
            Response valid = await ValidateObjetc(dto);
            if (!valid.IsSuccess)
                return valid;

            try
            {
                var entity = mapper.Map<ProductCategory>(dto);
                var data = await productCategoryDomain.AddAsync(entity);
                response.Result = data;
                response.IsSuccess = true;
                response.StatusCode = 200;
                response.Message = "Success";
                response.Code = "1201";
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
                response.Code = "1500";
            }

            return response;
        }

        public Response GetProductsCategories()
        {
            var response = new Response();
            try
            {
                //IEnumerable<ProductCategoryDto>
                var categories = productCategoryDomain.GetProductsCategories();
                var data = mapper.Map<IEnumerable<ProductCategoryDto>>(categories);
                if (data != null)
                {
                    response.IsSuccess = true;
                    response.Result = data;
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

        public Response GetProductsCategoriesFilters(ProductCategoryParameters parameters)
        {
            var response = new Response();
            try
            {
                var categories = productCategoryDomain.GetProductsCategoriesFilters(parameters);
                var data = mapper.Map<IEnumerable<ProductCategoryDto>>(categories);
                if (data != null)
                {
                    response.IsSuccess = true;
                    response.Result = data;
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

        public async Task<Response> ValidateObjetc(ProductCategoryDto productDto)
        {
            Response response = new Response();
            List<Error> errores = new List<Error>();

            if (string.IsNullOrEmpty(productDto.NameCategory))
            {
                response.IsSuccess = false;
                Error error = new Error()
                {
                    Code = "1410",
                    Message = "Field NameCategory is required"
                };
                errores.Add(error);
            }

            if (productDto.NameCategory != null && productDto.NameCategory.Length < 2)
            {
                Error error = new Error()
                {
                    Code = "1416",
                    Message = "Field NameCategory is not valid lenght"
                };
                errores.Add(error);
            }

            if (errores.Count > 1)
            {
                response.IsSuccess = false;
                response.StatusCode = 400;
                response.Message = "Multiple errors";
                response.Code = "1440";
                response.Result = errores;
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
