using PAS.Domain.Entities;

namespace PAS.Infrastructure.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetProducts();

        Task<IEnumerable<Product>> GetByName(string name);

    }
}
