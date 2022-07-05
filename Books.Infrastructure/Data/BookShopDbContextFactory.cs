using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Books.Infrastructure.Data
{
    public class BookShopDbContextFactory : IDesignTimeDbContextFactory<BookShopDbContext>
    {
        public BookShopDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<BookShopDbContext>();
                optionsBuilder.UseSqlServer("Server=RUSTY;Database=BookShop;Trusted_Connection=True;MultipleActiveResultSets=true");

                return new BookShopDbContext(optionsBuilder.Options);
            }
    }
}
