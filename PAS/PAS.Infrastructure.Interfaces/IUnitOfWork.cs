namespace PAS.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductCategoryRepository ProductCategoriesRepository { get; }

        int Complete();
    }
}
