using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Application.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
    }
}
