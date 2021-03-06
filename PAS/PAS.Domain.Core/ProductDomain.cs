using PAS.Domain.Entities;
using PAS.Domain.Interfaces;
using PAS.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Domain.Core
{
    public class ProductDomain : IProductDomain
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductDomain(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Product> GetByIdAsync(object id)
        {
            return await unitOfWork.ProductRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            return await unitOfWork.ProductRepository.GetByName(name);
        }
    }
}
