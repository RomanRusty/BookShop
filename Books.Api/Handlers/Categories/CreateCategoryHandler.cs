using AutoMapper;
using Books.Api.Queries.Books;
using Books.Api.Queries.Categories;
using Books.Contracts;
using Books.Core.Entities;
using Books.Core.Repositories;
using MediatR;

namespace Books.Api.Handlers.Categories
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryQuery, CategoryDto>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(CreateCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.CategoryCreateDto);

            await _repository.AddAsync(category);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
