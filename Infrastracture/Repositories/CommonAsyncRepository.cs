using ApplicationCore.RepositoryInterfaces;
using Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Repositories
{
    public class CommonAsyncRepository<T> : IAsyncRepository<T> where T: class
    {
        protected readonly CabsBookingDbContext _dbContext;

        public CommonAsyncRepository(CabsBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
           // await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
           // _dbContext.SaveChangesAsync();
        }

        public virtual async Task<bool> CommonSaveAsync()
        {
            return await (_dbContext.SaveChangesAsync()) > 0;
        }

        //public virtual async Task<T> DeleteAsync(T entity)
        //{
        //    _dbContext.Set<T>().Remove(entity);
        //    await _dbContext.SaveChangesAsync();
        //    return entity;
        //}

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _dbContext.Set<T>().Where(filter).CountAsync();
            }
            return await _dbContext.Set<T>().CountAsync();
        }

        public virtual async Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _dbContext.Set<T>().Where(filter).AnyAsync();
            }
            return await _dbContext.Set<T>().AnyAsync();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
            //_dbContext.SaveChangesAsync();
        }
    }
}
