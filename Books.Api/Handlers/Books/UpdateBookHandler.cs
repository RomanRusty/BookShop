using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.Api.Queries.Books;
using Books.Contracts.Exceptions;
using Books.Core.Entities;
using Books.Core.Repositories;
using MediatR;

namespace Books.Api.Handlers.Books
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookQuery>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public UpdateBookHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateBookQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != request.BookCreateDto.Id)
            {
                throw new NotFoundException("Book with such id does not exist", request.Id);
            }
            try
            {
                var book = _mapper.Map<Book>(request.BookCreateDto);
                await _repository.UpdateAsync(book);
            }
            catch (Exception)
            {
                if (await _repository.ExistsAsync(request.Id))
                {
                    throw new NotFoundException("Book already exists", request.Id);
                }
            }
            return Unit.Value;
        }
    }
}
