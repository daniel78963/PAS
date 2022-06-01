using PAS.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Application.Interfaces
{
    public interface IProductService : IGenericService<ProductDto>
    {
        Task<Response<IEnumerable<ProductDto>>> GetByName(string name);

    }
}
