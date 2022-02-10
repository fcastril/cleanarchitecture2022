using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected readonly MainContext _mainContext;

        public BaseRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            _mainContext.Set<T>().Add(entity);
            await _mainContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _mainContext.Set<T>().Remove(entity);
            await _mainContext.SaveChangesAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync() => await _mainContext.Set<T>().ToListAsync();

        public virtual async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate) => await _mainContext.Set<T>().Where(predicate).ToListAsync();

        public virtual async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string? includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _mainContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, List<Expression<Func<T, object>>> includes, bool disableTracking = true)
        {
            IQueryable<T> query = _mainContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();

        }

        public virtual async Task<T> GetByIdAsync(Guid Id) => await _mainContext!.Set<T>().FindAsync(Id) ?? new();

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _mainContext.Entry(entity).State = EntityState.Modified;
            await _mainContext.SaveChangesAsync();

            return entity;
        }
    }
}
