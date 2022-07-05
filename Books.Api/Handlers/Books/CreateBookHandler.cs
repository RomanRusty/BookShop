using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.Api.Queries.Books;
using Books.Contracts;
using Books.Core.Entities;
using Books.Core.Repositories;
using MediatR;

namespace Books.Api.Handlers.Books
{
    public class CreateBookHandler : IRequestHandler<CreateBookQuery, BookDto>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public CreateBookHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(CreateBookQuery request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request.BookCreateDto);

            await _repository.AddAsync(book);

            return _mapper.Map<BookDto>(book);
        }
    }
}
