using Microsoft.EntityFrameworkCore;
using Project.MovieStore.Domain.Abstract;
using System.Linq.Expressions;

namespace Project.MovieStore.Persistence.EFCore.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly MovieStoreDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(MovieStoreDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> WhereIf(IQueryable<T> source, bool condition,
        Expression<Func<T, bool>> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }

        public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, string includeProperties = "",
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool asNoTracking = true)
        {

            IQueryable<T> query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            query = Includes(query, includeProperties);

            if (orderBy is not null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        private IQueryable<T> Includes(IQueryable<T> query ,string includeProperties = "")
        {

            var includes = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if(includes.Length == 0)
                return query;

            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }


        public virtual async Task<T> GetAsync(Expression<Func<T, bool>>? predicate = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            query = Includes(query, includeProperties);

            return await query.FirstOrDefaultAsync();
        }


        public virtual async Task<T> GetByIdAsync<I>(I id)
        {
            return await _dbSet.FindAsync(id);
        }


        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task DeleteAsync<I>(I id)
        {
            T entity = await GetByIdAsync(id);
            Delete(entity);
        }

        public virtual void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().AnyAsync(predicate);
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {

            return await _dbSet.AsNoTracking().Where(predicate).CountAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }


    }
}
