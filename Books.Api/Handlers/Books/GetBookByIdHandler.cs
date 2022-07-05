using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.Api.Queries.Books;
using Books.Contracts;
using Books.Contracts.Exceptions;
using Books.Core.Repositories;
using MediatR;

namespace Books.Api.Handlers.Books
{
    public class GetBookByIdHandler:IRequestHandler<GetBookByIdQuery,BookDto>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetBookByIdHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.FindByIdAsync(request.Id);

            if (book == null)
            {
                throw new NotFoundException("Book not found", request.Id);
            }
            return _mapper.Map<BookDto>(book);
        }
    }
}
