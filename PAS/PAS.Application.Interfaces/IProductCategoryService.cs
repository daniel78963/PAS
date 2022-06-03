using PAS.Application.Dto;
using PAS.Application.QueryParameters;

namespace PAS.Application.Interfaces
{
    public interface IProductCategoryService
    {
        Task<Response<ProductCategoryDto>> GetByIdAsync(object id);
        Response<IEnumerable<ProductCategoryDto>> GetProductsCategories();
        Response<IEnumerable<ProductCategoryDto>> GetProductsCategoriesFilters(ProductCategoryParameters parameters);

    }
}
