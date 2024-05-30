using ConstructionFlow.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ConstructionFlow.DAL.UnitOfWork
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public void Delete(object id)
        {
            T entity = _db.Find(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public Task<T> Get(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db;
            if (include != null)
            {
                query = include(query);
            }

            return query?.FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db;
            if (include != null)
            {
                query = include(query);
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }

            return await query?.ToListAsync();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db;
            if (include != null)
            {
                query = include(query);
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }

            return query?.ToList();
        }

        public async Task<T> Insert(T entity)
        {

            _db.Add(entity);
            await _context.SaveChangesAsync();

            var entityType = typeof(T);
            var keyProperty = _context.Model.FindEntityType(entityType).FindPrimaryKey().Properties.FirstOrDefault();

            if (keyProperty == null)
            {
                throw new InvalidOperationException("No key property found for entity type " + entityType.Name);
            }

            var keyPropertyName = keyProperty.Name;
            var keyValue = entityType.GetProperty(keyPropertyName).GetValue(entity);

            IQueryable<T> query = _db;

            var navigationProperties = _context.Model
                .FindEntityType(entityType)
                .GetNavigations()
                .Select(n => n.Name);

            foreach (var navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);
            }

            var parameter = Expression.Parameter(typeof(T), "e");
            var predicate = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(
                    Expression.Property(parameter, keyPropertyName),
                    Expression.Constant(keyValue)
                ),
                parameter
            );

            var insertedEntity = await query.FirstOrDefaultAsync(predicate);

            return insertedEntity;
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}

