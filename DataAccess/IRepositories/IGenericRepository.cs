using System.Linq.Expressions;

namespace DataAccess.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The code Expression<Func<TEntity, bool>> filter means the caller will provide a lambda expression based on the TEntity type, and this expression will return a Boolean value. For example, if the repository is instantiated for the Student entity type, the code in the calling method might specify student => student.LastName == "Smith" for the filter parameter.
        ///The code Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy also means the caller will provide a lambda expression.But in this case, the input to the expression is an IQueryable object for the TEntity type.The expression will return an ordered version of that IQueryable object. For example, if the repository is instantiated for the Student entity type, the code in the calling method might specify q => q.OrderBy(s => s.LastName) for the orderBy parameter.
        ///The code in the Get method creates an IQueryable object and then applies the filter expression if there is one:
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null,
                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                  string includeProperties = "");
        TEntity GetById(object id);
        void Create(TEntity entity);
        void Delete(object id);
        void Update(TEntity entity);
        void Delete(TEntity entityToDelete);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        //Task<IQueryable<TEntity>> QueryAsync(
        //    Expression<Func<TEntity, bool>> filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    string includeProperties = ""
        //);
        Task<TEntity> GetByIdAsync(int ID);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int ID);
    }
}
