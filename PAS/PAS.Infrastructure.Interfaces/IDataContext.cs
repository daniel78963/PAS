using Microsoft.EntityFrameworkCore;
using PAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Infrastructure.Interfaces
{
    public interface IDataContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        Task<int> SaveChanges();
    }
}
