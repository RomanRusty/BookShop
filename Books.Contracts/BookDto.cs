using Books.Contracts.Enums;

namespace Books.Contracts
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public float? Price { get; set; }
        public BookCommentStatus CommentStatus { get; set; }
        public BookDownloadStatus DownloadStatus { get; set; }
        public BookWritingStatus WritingStatus { get; set; }
        public virtual CategoryDto Category { get; set; } = null!;
        public virtual AuthorDto Author { get; set; } = null!;
        public virtual BookAvatarImageDto? AvatarImage { get; set; }
        public virtual CycleDto? Cycle { get; set; }

        public virtual ICollection<BookTagDto> Tags { get; set; } = new HashSet<BookTagDto>();
        public virtual ICollection<CommentDto> Comments { get; set; } = new HashSet<CommentDto>();
        public virtual ICollection<ReaderBookDto> ReaderBooks { get; set; } = new HashSet<ReaderBookDto>();
        public virtual ICollection<BookChapterDto> Chapters { get; set; } = new HashSet<BookChapterDto>();
        public virtual ICollection<LikeDto> Likes { get; set; } = new HashSet<LikeDto>();
    }
}