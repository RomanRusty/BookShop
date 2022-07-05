namespace Books.Contracts
{
    public class CycleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int AuthorId { get; set; }
        public virtual AuthorDto Author { get; set; } = null!;

        public virtual ICollection<BookDto> Books { get; set; } = new HashSet<BookDto>();
    }
}
