namespace Books.Contracts
{
    public class BookAvatarImageDto
    {
        public int Id { get; set; }
        public byte[] Data { get; set; } = null!;
        public int BookId { get; set; }
        public virtual BookDto Book { get; set; } = null!;
    }
}