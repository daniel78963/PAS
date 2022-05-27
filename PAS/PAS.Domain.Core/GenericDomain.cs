using PAS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Domain.Core
{
    public class GenericDomain<T> : IGenericDomain<T> where T : class
    {
        public Task<T> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }
    }
}
