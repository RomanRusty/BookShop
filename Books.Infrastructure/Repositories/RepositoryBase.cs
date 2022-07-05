using System.Linq.Expressions;
using Books.Core.Entities.Base;
using Books.Core.Repositories;
using Books.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected BookShopDbContext Context;
        protected readonly DbSet<TEntity> DbSet;
        protected RepositoryBase(BookShopDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> FindAllAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Include(includeProperties).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet.Where(expression).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Include(includeProperties).Where(expression).AsNoTracking().ToListAsync();
        }
        public async Task<TEntity?> FindByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public async Task<TEntity?> FindByIdAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await Include(includeProperties)
                .FirstOrDefaultAsync(item => item.Id == id);
        }
        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();
        }
        public async Task UpdateStateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await FindByIdAsync(id);
            if (entity == null)
                throw new Exception("Entity not found");

            await DeleteAsync(entity);
        }
        public async Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }
        public async Task DeleteRangeAsync(int[] ids)
        {
            var entities = DbSet.Join(ids, str1 => str1.Id,
                str2 => str2,
                (str1, str2) => str1);
            await DeleteRangeAsync(entities);
        }
        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await FindByIdAsync(id) != null;
        }
        public async Task<bool> ExistsAsync(TEntity entity)
        {
            return await Context.FindAsync<TEntity>(entity) != null;
        }
        public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = DbSet;
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}