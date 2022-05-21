using AutoMapper;
using PAS.Application.Dto;
using PAS.Domain.Entities;

namespace PAS.Application.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
        }
    }
}
