namespace PAS.Application.Mapper
{
    public interface IMapperGenericHelper<T, C>
    {
        C ToMapper(T model);
    }
}
