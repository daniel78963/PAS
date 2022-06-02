using Microsoft.EntityFrameworkCore;
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
        //private readonly IGenericRepository<TEntity> genericRepository;
        //internal DataContext context;
        //internal DbSet<TEntity> dbSet;

        public UnitOfWork(DataContext context, ISortHelper<ProductCategory> sortHelper)
        {
            this.context = context;
            this.sortHelper = sortHelper;
            //this.genericRepository = genericRepository;
            ProductCategoriesRepository = new ProductCategoryRepository(this.context, sortHelper);
            //Projects = new ProjectRepository(_context);
            //this.context = context;
            //this.dbSet = context.Set<TEntity>();
        }

        public IProductCategoryRepository ProductCategoriesRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }


        //public virtual async Task<IEnumerable<TEntity>> AllAsync()
        //{
        //    IQueryable<TEntity> query = dbSet;
        //    return await query.ToListAsync();
        //}

        public int Complete()
        {
            return context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
