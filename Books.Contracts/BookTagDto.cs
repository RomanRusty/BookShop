namespace Books.Contracts
{
    public class BookTagDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<BookDto> Books { get; set; } = new HashSet<BookDto>();
    }
}
