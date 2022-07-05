using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Contracts;
using MediatR;

namespace Books.Api.Queries.Books
{
    public class GetBookByIdQuery:IRequest<BookDto>
    {
        public int Id { get; }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
