using AutoMapper;
using PAS.Application.Dto;
using PAS.Application.Interfaces;
using PAS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDomain productDomain;
        private readonly IMapper mapper;

        public ProductService(IProductDomain productDomain, IMapper mapper)
        {
            this.productDomain = productDomain;
            this.mapper = mapper;
        }

        public Task<ProductDto> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }
         
        public async Task<Response> GetByName(string name)
        {
            var response = new Response();
            try
            {

                var entities = productDomain.GetByName(name);
               var data = mapper.Map<IEnumerable<ProductDto>>(entities);
                if (data != null)
                {
                    response.IsSuccess = true;
                    response.Result = data;
                    response.Message = "Success";
                    response.Code = "1201";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
         
    }
}
