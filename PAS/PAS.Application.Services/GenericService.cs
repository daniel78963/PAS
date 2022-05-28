using PAS.Application.Interfaces;
using PAS.Domain.Interfaces;

namespace PAS.Application.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        public IProductCategoryService ProductCategoriesService { get; private set; }

        private readonly IGenericDomain<T> genericDomain;

        public GenericService(IGenericDomain<T> genericDomain)
        {
            this.genericDomain = genericDomain;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await genericDomain.GetByIdAsync(id);
        }
    }
}
