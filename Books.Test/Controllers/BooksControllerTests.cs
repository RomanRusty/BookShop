using System.Net;
using System.Net.Http.Json;
using Books.Contracts.ApiRoutes;

namespace Books.Test.Controllers
{
    public class BooksControllerTests : IntegrationTestBase
    {
        [Fact]
        public async Task GetAll_WithoutAnyBooks_ReturnsEmptyResponse()
        {
            // Arrange
            //await AuthenticateAsync(UserRoles.Admin);

            // Act
            var response = await Client.GetAsync(ApiRoutes.Books.GetAll);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadFromJsonAsync<IEnumerable<BookDto>>()).Should().BeEmpty();
        }

        [Fact]
        public void GetAll_WithBooks_ReturnsCollectionOfBooks()
        {
            // Arrange
            
            // Act

            // Assert

        }
    }
}
