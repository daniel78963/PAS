using Microsoft.EntityFrameworkCore;
using PAS.Domain.Entities;
using PAS.Infrastructure.Interfaces;

namespace PAS.Infrastructure.Data
{
    //public class DataContext : DbContext, IDataContext
    public class DataContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
