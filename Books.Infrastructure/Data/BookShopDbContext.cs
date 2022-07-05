using Books.Core.Entities;
using Books.Core.Entities.Base;
using Books.Core.Entities.Identity;
using Books.Core.Entities.Images;
using Books.Core.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Data
{
    public class BookShopDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options)
        {

        }

        //public override  DbSet<ApplicationUser> Users { get; set; } = null!;
        public virtual DbSet<UserAvatarImage> UserAvatarImages { get; set; } = null!;
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Reader> Readers { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public override DbSet<ApplicationRole> Roles { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookChapter> BookChapters { get; set; } = null!;
        public virtual DbSet<BookTag> BookTags { get; set; } = null!;
        public virtual DbSet<Cycle> Cycles { get; set; } = null!;

        public virtual DbSet<BookAvatarImage> BookAvatarImages { get; set; } = null!;
        public virtual DbSet<ReaderBook> ReaderBooks { get; set; } = null!;

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<GlobalNotification> GlobalNotifications { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users");
            modelBuilder.Entity<ApplicationRole>()
                .ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UserRoles");
                entity.HasKey(key => new { key.UserId, key.RoleId });
            });
            modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogins");
                entity.HasKey(key => new { key.ProviderKey, key.LoginProvider });
            });
            modelBuilder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaims");

            });
            modelBuilder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserTokens");
                entity.HasKey(key => new { key.UserId, key.LoginProvider, key.Name });

            });
        }
        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken token = default)
        {
            foreach (var entity in ChangeTracker
                         .Entries()
                         .Where(x => x.Entity is IDateEntity && x.State == EntityState.Modified)
                         .Select(x => x.Entity)
                         .Cast<IDateEntity>())
            {
                entity.UpdatedAt = DateTime.Now;
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, token);
        }
    }
}