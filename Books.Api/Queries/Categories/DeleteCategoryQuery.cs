using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Books.Api.Queries.Categories
{
    public class DeleteCategoryQuery : IRequest
    {
        public int Id { get; }
        public DeleteCategoryQuery(int id)
        {
            Id = id;
        }
    }
}
