using DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal ApplicationContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        /*
         * The code Expression<Func<TEntity, bool>> filter means the caller will provide a lambda expression based on the TEntity type, 
         * and this expression will return a Boolean value. For example, if the repository is instantiated for the Student entity type, the code in the calling method might specify student => student.LastName == "Smith" for the filter parameter.
         *  The code Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy also means the caller will provide a lambda expression. But in this case, the input to the expression is an IQueryable object for the TEntity type. The expression will return an ordered version of that IQueryable object. For example, if the repository is instantiated for the Student entity type, the code in the calling method might specify q => q.OrderBy(s => s.LastName) for the orderBy parameter.
         */
        public virtual IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            //The code in the Get method creates an IQueryable object and then applies the filter expression if there is one:
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            //Next it applies the eager-loading expressions after parsing the comma-delimited list:
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            //Finally, it applies the orderBy expression if there is one and returns the results; otherwise it returns the results from the unordered query:
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            var existingEntity = _dbSet.Find(entityToUpdate);
            if (existingEntity != null)
            {
                _dbSet.Attach(entityToUpdate);
                _context.Entry(entityToUpdate).State = EntityState.Modified;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        //public virtual async Task<IQueryable<TEntity>> QueryAsync(
        //    Expression<Func<TEntity, bool>> filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    string includeProperties = "")
        //{
        //    IQueryable<TEntity> query = _dbSet;

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    if (orderBy != null)
        //    {
        //        query = orderBy(query);
        //    }

        //    return await Task.FromResult(query);
        //}

        public virtual async Task<TEntity> GetByIdAsync(int ID)
        {
            var entity = await _dbSet.FindAsync(ID);
            if (entity != null)
            {
                return entity;
            }
            return null;
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            // Example async operation before updating
            var existingEntity = await _dbSet.FindAsync(entity);
            if (existingEntity != null)
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual async Task DeleteAsync(int ID)
        {
            var entity = await _dbSet.FindAsync(ID);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
    }
}
