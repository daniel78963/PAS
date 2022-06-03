using PAS.Application.Dto;
using PAS.Application.QueryParameters;

namespace PAS.Application.Interfaces
{
    public interface IProductCategoryService
    {
        public Task<Response<ProductCategoryDto>> GetByIdAsync(object id);
        public Response<IEnumerable<ProductCategoryDto>> GetProductsCategories();
        public Response<IEnumerable<ProductCategoryDto>> GetProductsCategoriesFilters(ProductCategoryParameters parameters);

    }
}
