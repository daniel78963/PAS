using PAS.Domain.Entities;

namespace PAS.Domain.Interfaces
{
    public interface IProductDomain
    {
        Task<IEnumerable<Product>> GetByName(string name);
    }
}
