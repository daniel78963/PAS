using PAS.Application.Dto;
using PAS.Application.QueryParameters;

namespace PAS.Application.Interfaces
{
    public interface IProductCategoryService
    {
        public Response<IEnumerable<ProductCategoryDto>> GetProductsCategories();
        public Response<IEnumerable<ProductCategoryDto>> GetProductsCategoriesFilters(ProductCategoryParameters parameters);

    }
}
