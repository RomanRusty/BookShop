using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.Api.Queries.Books;
using Books.Contracts.Exceptions;
using Books.Core.Repositories;
using MediatR;

namespace Books.Api.Handlers.Books
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookQuery>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public DeleteBookHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.FindByIdAsync(request.Id);

            if (book == null)
            {
                throw new NotFoundException("book with such id does not exists", request.Id);
            }
            await _repository.DeleteAsync(book);
            return Unit.Value;
        }
    }
}
