using PAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Infrastructure.Interfaces
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetProductsCategories();
        IEnumerable<ProductCategory> GetProductsCategories(string parameters);
    }
}
