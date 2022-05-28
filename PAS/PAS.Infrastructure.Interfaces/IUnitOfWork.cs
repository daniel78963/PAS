namespace PAS.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductCategoryRepository ProductCategoriesRepository { get; }
        IProductRepository ProductRepository { get; }

        int Complete();

        Task CompleteAsync();
    }
}
