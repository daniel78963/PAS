using Microsoft.EntityFrameworkCore;
using PAS.Infrastructure.Data;
using PAS.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Infrastructure.Repositories
{
    //public class GenericRepository<TEntity> where TEntity : class
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal DataContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        //public virtual IEnumerable<TEntity> Get(
        //    Expression<Func<TEntity, bool>> filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    string includeProperties = "")
        //{
        //    IQueryable<TEntity> query = dbSet;

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}

        public virtual IEnumerable<TEntity> All()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> AllAsync()
        {
            IQueryable<TEntity> query = dbSet;
            return await query.ToListAsync();
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual bool Add(TEntity entity)
        {
            dbSet.Add(entity);
            return true;
        }

        public virtual async Task<bool> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual bool Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
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
            TEntity entityToDelete = await dbSet.FindAsync(id);
            //Delete(entityToDelete);
            if (entityToDelete == null) return false;

            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            return true;
        }

        //public virtual void Delete(TEntity entityToDelete)
        //{
        //    if (context.Entry(entityToDelete).State == EntityState.Detached)
        //    {
        //        dbSet.Attach(entityToDelete);
        //    }
        //    dbSet.Remove(entityToDelete);
        //}

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entityToUpdate, object id)
        {
            TEntity exist = await dbSet.FindAsync(id);
            //if (exist == null)
            //    throw new ArgumentNullException("entity");
            ////return false;
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(entityToUpdate);
                //dbSet.Update(entityToUpdate);
                //dbSet.Attach(entityToUpdate);
                //context.Entry(entityToUpdate).State = EntityState.Modified;
                return true;
            }
            return false;
        }
    }
}
