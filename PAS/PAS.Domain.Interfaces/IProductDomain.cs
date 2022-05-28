using PAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Domain.Interfaces
{
    public interface IProductDomain : IGenericDomain<Product>
    {
        Task<IEnumerable<Product>> GetByName(string name);
    }
}
