using PAS.Application.Interfaces;

namespace PAS.Application.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        public Task<T> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }
    }
}
