using Microsoft.EntityFrameworkCore;
using PAS.Domain.Entities;

namespace PAS.Infrastructure.Interfaces
{
    public interface IDataContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        //Task<int> SaveChanges();
    }
}
