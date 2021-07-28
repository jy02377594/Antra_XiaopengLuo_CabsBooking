﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T: class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity);
        void Add(T entity);
        Task<T> UpdateAsync(T entity);
        void Update(T entity);
        //Task<T> DeleteAsync(T entity);
        void Delete(T entity);
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> CommonSaveAsync();
    }
}
