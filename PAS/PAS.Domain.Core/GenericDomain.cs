using PAS.Domain.Interfaces;
using PAS.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Domain.Core
{
    public class GenericDomain<T> : IGenericDomain<T> where T : class
    {
        private readonly IUnitOfWork unitOfWork;

        public GenericDomain(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IProductDomain ProductDomain { get; private set; }

        public virtual IEnumerable<T> All()
        {
            //unitOfWork.
            throw new NotImplementedException();
        }
        public Task<T> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }
    }
}
