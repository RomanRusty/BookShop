using System.Linq.Expressions;

namespace Books.Core.Repositories
{
    public interface IRepositoryBase<TEntity>
    {
        Task<IEnumerable<TEntity>> FindAllAsync();
        Task<IEnumerable<TEntity>> FindAllAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression,
            params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity?> FindByIdAsync(int id);
        Task<TEntity?> FindByIdAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateStateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(int[] ids);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(TEntity item);
        IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties);
    }
}