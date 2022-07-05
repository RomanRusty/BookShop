using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.Api.Queries.Books;
using Books.Contracts;
using Books.Core.Repositories;
using MediatR;

namespace Books.Api.Handlers.Books
{
    public class GetAllBooksHandler:IRequestHandler<GetAllBooksQuery,IEnumerable<BookDto>>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;
        public GetAllBooksHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.FindAllAsync(item => item.Author,
                item => item.AvatarImage,
                item => item.Category,
                item => item.Cycle);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
