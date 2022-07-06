using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PAS.Domain.Entities;
using PAS.Infrastructure.Interfaces;

namespace PAS.Infrastructure.Data
{
    //public class DataContext : DbContext, IDataContext
    //public class DataContext : DbContext
    public class DataContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Book> Books { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            string connection = "server=.\\SQLEXPRESS2016; database=PAS; user id=sa; password=Medellin1;Trusted_Connection=False;MultipleActiveResultSets=true;";

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            //optionsBuilder.UseSqlServer(connection, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            optionsBuilder.UseSqlServer(connection);
            //options.UseSqlServer(connection, b => b.MigrationsAssembly("PAS.Application.API"))
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
