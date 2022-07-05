using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Contracts;
using MediatR;

namespace Books.Api.Queries.Books
{
    public class GetAllBooksQuery:IRequest<IEnumerable<BookDto>>
    {

    }
}
