using Books.Contracts;
using MediatR;

namespace Books.Api.Queries.Categories
{
    public class CreateCategoryQuery : IRequest<CategoryDto>
    {
        public CategoryCreateDto CategoryCreateDto { get; }

        public CreateCategoryQuery(CategoryCreateDto categoryCreateDto)
        {
            CategoryCreateDto = categoryCreateDto;
        }
    }
}
