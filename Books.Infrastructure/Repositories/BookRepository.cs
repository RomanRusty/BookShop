using Books.Core.Entities;
using Books.Core.Repositories;
using Books.Infrastructure.Data;

namespace Books.Infrastructure.Repositories
{
    public class BookRepository : RepositoryBase<Book>,IBookRepository
    {
        public BookRepository(BookShopDbContext context) : base(context)
        {
        }
        
    }
}