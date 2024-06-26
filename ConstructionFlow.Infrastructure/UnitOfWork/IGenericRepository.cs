﻿using ConstructionFlow.Domain.Model;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.Infrastructure.UnitOfWork
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        IList<T> GetAll(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<T> Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        void Delete(object id);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
