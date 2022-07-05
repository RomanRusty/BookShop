using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Books.Core.Entities.Base;
using Books.Core.Entities.Enums;
using Books.Core.Entities.Images;
using Books.Core.Entities.Users;

namespace Books.Core.Entities
{
    [Table("Books")]
    public class Book : BaseEntity
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 symbols.")]
        [MaxLength(255, ErrorMessage = "Name must be less than 255 symbols.")]
        public string Name { get; set; } = null!;
        [MaxLength(255, ErrorMessage = "Description must be less than 255 symbols.")]
        public string Description { get; set; } = null!;
        public float? Price { get; set; }
        public BookCommentStatus CommentStatus { get; set; }
        public BookDownloadStatus DownloadStatus { get; set; }
        public BookWritingStatus WritingStatus { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; } = null!;
        public virtual BookAvatarImage? AvatarImage { get; set; }
        public virtual Cycle? Cycle { get; set; }

        public virtual ICollection<BookTag> Tags { get; set; } = new HashSet<BookTag>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<ReaderBook> ReaderBooks { get; set; } = new HashSet<ReaderBook>();
        public virtual ICollection<BookChapter> Chapters { get; set; } = new HashSet<BookChapter>();
        public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();
    }
}