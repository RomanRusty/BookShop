namespace Books.Contracts
{
    public class LikeDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual BookDto Book { get; set; } = null!;
        public int UserId { get; set; }
        public virtual ApplicationUserDto User { get; set; } = null!;
    }
}
