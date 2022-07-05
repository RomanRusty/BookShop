using AutoMapper;
using Books.Api.Queries.Categories;
using Books.Contracts.Exceptions;
using Books.Core.Entities;
using Books.Core.Repositories;
using MediatR;

namespace Books.Api.Handlers.Categories
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryQuery>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCategoryQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != request.CategoryCreateDto.Id)
            {
                throw new NotFoundException("Category with such id does not exist", request.Id);
            }
            try
            {
                var category = _mapper.Map<Category>(request.CategoryCreateDto);
                await _repository.UpdateAsync(category);
            }
            catch (Exception)
            {
                if (await _repository.ExistsAsync(request.Id))
                {
                    throw new NotFoundException("Category already exists", request.Id);
                }
            }
            return Unit.Value;
        }
    }
}
