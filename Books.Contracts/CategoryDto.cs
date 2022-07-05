namespace Books.Contracts
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<BookDto> Books { get; set; } = new HashSet<BookDto>();
    }
}