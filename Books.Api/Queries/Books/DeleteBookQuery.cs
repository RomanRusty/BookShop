using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Books.Api.Queries.Books
{
    public class DeleteBookQuery : IRequest
    {
        public int Id { get; }
        public DeleteBookQuery(int id)
        {
            Id = id;
        }
    }
}
