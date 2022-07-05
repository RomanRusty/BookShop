using AutoMapper;
using Books.Contracts;
using Books.Core.Entities;

namespace Books.Infrastructure.Profiles
{
    public class CategoriesProfile:Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<CategoryCreateDto, Category>();
        }
    }
}
