namespace PAS.Domain.Interfaces
{
    public interface IGenericDomain<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
    }
}
