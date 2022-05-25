using PAS.Application.QueryParameters;
using PAS.Domain.Entities;
using PAS.Infrastructure.Data;
using PAS.Infrastructure.Interfaces;

namespace PAS.Infrastructure.Repositories
{
    public class ProductCategoryRepository :  GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        private readonly DataContext dataContext;
        private readonly ISortHelper<ProductCategory> sortHelper;

        public ProductCategoryRepository(DataContext dataContext, ISortHelper<ProductCategory> sortHelper) : base(dataContext)
        {
            this.dataContext = dataContext;
            this.sortHelper = sortHelper;
        }

        public IEnumerable<ProductCategory> GetProductsCategories()
        {
            return dataContext.ProductCategory;
        }

        public IEnumerable<ProductCategory> GetProductsCategoriesFilters(ProductCategoryParameters parameters)
        {
            //return _context.Developers.OrderByDescending(d => d.Followers).Take(count).ToList();
            var categories = dataContext.ProductCategory;
            return sortHelper.ApplySort(categories, parameters.OrderBy); 
        }
    }
}
