using Books.Contracts.ApiRoutes;
using Books.Contracts.Responses;
using Books.Core.Entities.Identity;
using Books.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Books.Test
{
    public abstract class IntegrationTestBase
    {
        protected readonly HttpClient Client;
        private readonly BookShopDbContext _context;
        protected IntegrationTestBase()
        {
            var appFactory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.RemoveAll(typeof(BookShopDbContext));
                    services.AddDbContext<BookShopDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("TestDbV6");
                    });

                });
            });
            Client = appFactory.CreateClient();
            using var scope = appFactory.Services.CreateScope();
            _context = scope.ServiceProvider.GetRequiredService<BookShopDbContext>();
            //_context.Database.EnsureDeletedAsync();
            if (!_context.Roles.Any())
            {
                _context.Roles.AddRangeAsync(new[]
                {
                    new ApplicationRole("Admin"),
                    new ApplicationRole("Author"),
                    new ApplicationRole("Reader")
                });
                _context.SaveChangesAsync();
            }



        }
        ~IntegrationTestBase()
        {
            _context.Database.EnsureDeletedAsync();
        }
        protected async Task AuthenticateAsync(string role)
        {
            var token = await GetJwtBearerAsync(role);
            token.Should().NotBeNullOrEmpty();
            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", token);
        }

        private async Task<string?> GetJwtBearerAsync(string role)
        {
            var uri = role switch
            {
                UserRoles.Reader => ApiRoutes.Auth.RegisterReader,
                UserRoles.Author => ApiRoutes.Auth.RegisterAuthor,
                UserRoles.Admin => ApiRoutes.Auth.RegisterAdmin,
                _ => string.Empty
            };
            await Client.PostAsJsonAsync(uri, new RegistrationDto()
            {
                Email = "test@integration3.com",
                Password = "SomePass1234!"
            });
            var loginResponse = await Client.PostAsJsonAsync(ApiRoutes.Auth.Login, new LoginDto()
            {
                Email = "test@integration3.com",
                Password = "SomePass1234!"
            });
            loginResponse.IsSuccessStatusCode.Should().BeTrue();
            var result = await loginResponse.Content.ReadFromJsonAsync<AuthSuccessResponse>();
            return result?.Token;
        }
    }
}
