using AutoMapper;
using Books.Core.Entities;
using Books.Contracts;
namespace Books.Infrastructure.Profiles
{
    public class BooksProfile:Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookDto>();

            CreateMap<BookCreateDto, Book>();
        }
    }
}
