namespace PAS.Domain.Interfaces
{
    public interface IGenericDomain<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
        //IEnumerable<T> All();

        //TODO: UPDATE ASYNC
        IEnumerable<T> All();
        Task<IEnumerable<T>> AllAsync();
        T GetById(object id);
        //Task<T> GetByIdAsync(object id);
        bool Add(T entity);
        Task<bool> AddAsync(T entity);
        bool Delete(object id);
        Task<bool> DeleteAsync(object id);
        //Task<bool> Upsert(TEntity entity);
        void Update(T entity);
        //Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
