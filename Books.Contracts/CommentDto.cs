namespace Books.Contracts
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;

        public int BookId { get; set; }
        public virtual BookDto Book { get; set; } = null!;
        public int CreatorId { get; set; }
        public virtual ApplicationUserDto Creator { get; set; } = null!;
    }
}
