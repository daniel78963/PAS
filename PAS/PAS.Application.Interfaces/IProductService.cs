using PAS.Application.Dto;

namespace PAS.Application.Interfaces
{
    public interface IProductService
    {
        Task<Response> GetByName(string name);
    }
}
