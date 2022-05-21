using PAS.Application.Dto;

namespace PAS.Application.Interfaces
{
    public interface IProductCategoryService
    {

        public Response<IEnumerable<ProductCategoryDto>> GetProductsCategories();

        public Response<IEnumerable<ProductCategoryDto>> GetProductsCategories(string parameters);

    }
}
