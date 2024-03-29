﻿using Domain.Common;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
                                        string? includeString = null,
                                        bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate,
                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
                                List<Expression<Func<T, object>>> includes,
                                bool disableTracking = true);
        Task<T> GetByIdAsync(Guid Id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
    }
}
