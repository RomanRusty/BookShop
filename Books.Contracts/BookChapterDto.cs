namespace Books.Contracts
{
    public class BookChapterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Text { get; set; } = null!;

        public virtual BookDto Book { get; set; } = null!;
    }
}
