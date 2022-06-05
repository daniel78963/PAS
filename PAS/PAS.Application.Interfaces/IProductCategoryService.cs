using PAS.Application.Dto;
using PAS.Application.QueryParameters;

namespace PAS.Application.Interfaces
{
    public interface IProductCategoryService
    {
        //Task<Response<ProductCategoryDto>> GetByIdAsync(object id);
        //Task<Response<bool>> AddAsync(ProductCategoryDto dto);
        //Response<IEnumerable<ProductCategoryDto>> GetProductsCategories();
        //Response<IEnumerable<ProductCategoryDto>> GetProductsCategoriesFilters(ProductCategoryParameters parameters);
        Task<Response> GetByIdAsync(object id);
        Task<Response> AddAsync(ProductCategoryDto dto);
        Task<Response> UpdateASync(ProductCategoryDto dto);
        Response GetProductsCategories();
        Response GetProductsCategoriesFilters(ProductCategoryParameters parameters);

    }
}
