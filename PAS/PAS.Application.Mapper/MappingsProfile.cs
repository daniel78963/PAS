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
            //Mapping to Properties with different Names
        //    CreateMap<Product, ProductDto>()
        //.ForMember(dest =>
        //    dest.Name,
        //    opt => opt.MapFrom(src => src.Name))
        //.ForMember(dest =>
        //    dest.Description,
        //    opt => opt.MapFrom(src => src.Description))
        //.ReverseMap();
        }
    }
}
