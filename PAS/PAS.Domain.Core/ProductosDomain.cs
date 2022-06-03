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
    public class ProductosDomain : GenericDomain<Product>, IProductosDomain
    {
        public ProductosDomain(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
