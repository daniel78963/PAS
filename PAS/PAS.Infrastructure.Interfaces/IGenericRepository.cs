using System.Linq.Expressions;

namespace PAS.Infrastructure.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //TODO: UPDATE ASYNC
        IEnumerable<TEntity> All();
        Task<IEnumerable<TEntity>> AllAsync();
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
        bool Add(TEntity entity);
        Task<bool> AddAsync(TEntity entity);
        bool Delete(object id);
        Task<bool> DeleteAsync(object id);
        //Task<bool> Upsert(TEntity entity);
        void Update(TEntity entity);
        //Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
