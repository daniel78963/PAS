using Microsoft.EntityFrameworkCore;
using PAS.Domain.Entities;

namespace PAS.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product > Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
