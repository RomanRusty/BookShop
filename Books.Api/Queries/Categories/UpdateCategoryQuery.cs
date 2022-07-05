using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Contracts;
using MediatR;

namespace Books.Api.Queries.Categories
{
    public class UpdateCategoryQuery : IRequest
    {
        public int Id { get; }
        public CategoryCreateDto CategoryCreateDto { get; }

        public UpdateCategoryQuery(int id, CategoryCreateDto categoryCreateDto)
        {
            Id = id;
            CategoryCreateDto = categoryCreateDto;
        }
    }
}
