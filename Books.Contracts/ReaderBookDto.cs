using Books.Contracts.Enums;

namespace Books.Contracts
{
    public class ReaderBookDto
    {
        public int Id { get; set; }
        public ReaderBookStatus Status { get; set; }

        public int ReaderId { get; set; }
        public virtual ReaderDto Reader { get; set; } = null!;
        public int BookId { get; set; }
        public virtual BookDto Book { get; set; } = null!;
    }
}
