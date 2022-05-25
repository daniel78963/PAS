using PAS.Domain.Entities;
using PAS.Infrastructure.Data;
using PAS.Infrastructure.Interfaces;

namespace PAS.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //TODO SortHelper T
        private readonly DataContext context;
        private readonly ISortHelper<ProductCategory> sortHelper;

        public UnitOfWork(DataContext context, ISortHelper<ProductCategory> sortHelper)
        {
            this.context = context;
            this.sortHelper = sortHelper;
            ProductCategoriesRepository = new ProductCategoryRepository(this.context, sortHelper);
            //Projects = new ProjectRepository(_context);
        }
        public IProductCategoryRepository ProductCategoriesRepository { get; private set; }
        //public IProjectRepository Projects { get; private set; }
        public int Complete()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
