namespace PAS.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductCategoryRepository ProductCategories { get; }

        int Complete();
    }
}
