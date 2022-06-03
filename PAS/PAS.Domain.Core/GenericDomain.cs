using PAS.Domain.Interfaces;
using PAS.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Domain.Core
{
    public class GenericDomain<T> : IGenericDomain<T> where T : class
    {
        private readonly IUnitOfWork unitOfWork;

        public GenericDomain(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IProductDomain ProductDomain { get; private set; }

        public virtual IEnumerable<T> All()
        {
            //unitOfWork.
            throw new NotImplementedException();
        }
        public virtual Task<T> GetByIdAsync(object id)
        {
            //unitOfWork.
            throw new NotImplementedException();
        }

        //TODO: UPDATE ASYNC
        public virtual IEnumerable<T> All()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            IQueryable<T> query = dbSet;
            return await query.ToListAsync();
        }

        public virtual T GetById(object id)
        {
            return dbSet.Find(id);
        }

        //public virtual async Task<T> GetByIdAsync(object id)
        //{
        //    return await dbSet.FindAsync(id);
        //}

        public virtual bool Add(T entity)
        {
            dbSet.Add(entity);
            return true;
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual bool Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            //Delete(entityToDelete);
            if (entityToDelete == null) return false;

            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            T entityToDelete = await dbSet.FindAsync(id);
            //Delete(entityToDelete);
            if (entityToDelete == null) return false;

            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            return true;
        }

        //public virtual void Delete(T entityToDelete)
        //{
        //    if (context.Entry(entityToDelete).State == EntityState.Detached)
        //    {
        //        dbSet.Attach(entityToDelete);
        //    }
        //    dbSet.Remove(entityToDelete);
        //}

        public virtual void Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        //public virtual Task<bool> UpdateASync(T entityToUpdate)
        //{
        //    //dbSet.Attach(entityToUpdate);
        //    //context.Entry(entityToUpdate).State = EntityState.Modified;
        //     dbSet.Update(entityToUpdate);
        //    return   true;
        //}
    }
}
