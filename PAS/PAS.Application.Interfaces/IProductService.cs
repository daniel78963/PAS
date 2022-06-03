using PAS.Application.Dto;

namespace PAS.Application.Interfaces
{
    public interface IProductService
    {
        Task<Response<IEnumerable<ProductDto>>> GetByName(string name);
    }
}
