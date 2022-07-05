using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Contracts;
using MediatR;

namespace Books.Api.Queries.Books
{
    public class UpdateBookQuery:IRequest
    {
        public int Id { get; }
        public BookCreateDto BookCreateDto { get; }

        public UpdateBookQuery(int id, BookCreateDto bookCreateDto)
        {
            Id = id;
            BookCreateDto = bookCreateDto;
        }
    }
}
