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
    public class ProductoService : IProductoService
    {
        private readonly IProductosDomain productosDomain;
        private readonly IMapper mapper;

        public ProductoService(IProductosDomain productosDomain, IMapper mapper)
        {
            this.productosDomain = productosDomain;
            this.mapper = mapper;
        }

        public async Task<Response<ProductDto>> GetByIdAsync(int Id)
        {
        
            var response = new Response<ProductDto>();
            try
            {
                //var entities = productDomain.GetByName(name);
                var entities = await productosDomain.GetByIdAsync(Id);
                response.Data = mapper.Map<ProductDto>(entities);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
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
