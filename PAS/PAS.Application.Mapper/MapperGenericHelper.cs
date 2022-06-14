using AutoMapper;
using System.Collections.Generic;

namespace PAS.Application.Mapper
{
    public static class MapperGenericHelper<T, C>
    {
        public static C ToMapper(T model)
        {
            var config = new MapperConfiguration(mc => mc.CreateMap<T, C>());
            var mapper = new AutoMapper.Mapper(config);

            return mapper.Map<T, C>(model);
        }
    }
}
