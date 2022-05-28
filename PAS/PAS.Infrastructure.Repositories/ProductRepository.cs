using Microsoft.EntityFrameworkCore;
using PAS.Domain.Entities;
using PAS.Infrastructure.Data;
using PAS.Infrastructure.Interfaces;

namespace PAS.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext dataContext;
        private readonly ISortHelper<Product> sortHelper;

        public ProductRepository(DataContext dataContext, ISortHelper<Product> sortHelper) : base(dataContext)
        {
            this.dataContext = dataContext;
            this.sortHelper = sortHelper;
        }

        public IEnumerable<Product> GetProducts()
        {
            return dataContext.Products;
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            return await dataContext.Products.Where(p => p.Name == name).ToListAsync();
        }
    }
}
