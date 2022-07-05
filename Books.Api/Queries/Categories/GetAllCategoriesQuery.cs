using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Contracts;
using MediatR;

namespace Books.Api.Queries.Categories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {

    }
}
