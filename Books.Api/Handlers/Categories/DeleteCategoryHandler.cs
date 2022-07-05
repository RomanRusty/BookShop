using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.Api.Queries.Categories;
using Books.Contracts;
using Books.Contracts.Exceptions;
using Books.Core.Entities;
using Books.Core.Repositories;
using MediatR;

namespace Books.Api.Handlers.Categories
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryQuery>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public DeleteCategoryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.FindByIdAsync(request.Id);

            if (category == null)
            {
                throw new NotFoundException("book with such id does not exists", request.Id);
            }
            await _repository.DeleteAsync(category);
            return Unit.Value;
        }
    }
}