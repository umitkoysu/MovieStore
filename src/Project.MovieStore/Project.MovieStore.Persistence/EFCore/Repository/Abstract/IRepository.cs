using Project.MovieStore.Domain.Abstract;
using System.Linq.Expressions;

namespace Project.MovieStore.Persistence.EFCore.Repository
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        Task AddAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        Task DeleteAsync<I>(I id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, string includeProperties = "", Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool asNoTracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>>? predicate = null, string includeProperties = "");
        Task<T> GetByIdAsync<I>(I id);
        Task<bool> SaveAsync();
        Task UpdateAsync(T entity);
        IQueryable<T> WhereIf(IQueryable<T> source, bool condition, Expression<Func<T, bool>> predicate);
    }
}