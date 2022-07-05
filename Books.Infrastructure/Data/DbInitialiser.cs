using Books.Contracts;
using Books.Core.Entities;
using Books.Core.Entities.Identity;
using Books.Core.Entities.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeDatabase(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            using (var roleManger = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>())
            {
                if (!roleManger.Roles.Any())
                {
                    await roleManger.CreateAsync(new ApplicationRole { Name = UserRoles.Admin });
                    await roleManger.CreateAsync(new ApplicationRole { Name = UserRoles.Reader });
                    await roleManger.CreateAsync(new ApplicationRole { Name = UserRoles.Author });
                }
            }
            //using (var userManger = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>())
            //{
            //    if (!userManger.Users.Any())
            //    {
            //        var admin = new Admin()
            //        {
            //            Email = "admin@gmail.com",
            //            UserName = "admin@gmail.com",
            //            //PhoneNumber = "+111111111111",
            //            EmailConfirmed = true,
            //            PhoneNumberConfirmed = true
            //        };
            //        await userManger.CreateAsync(admin, "Admin1");

            //        await userManger.AddToRoleAsync(admin, UserRoles.Admin);
            //    }
            //}

        }
    }
}
