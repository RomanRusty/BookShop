using Books.Core.Entities;
using Books.Core.Repositories;
using Books.Infrastructure.Data;

namespace Books.Infrastructure.Repositories
{
    public class CategoryRepository:RepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(BookShopDbContext context) : base(context)
        {
        
        }
    }
}