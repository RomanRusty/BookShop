using System.ComponentModel.DataAnnotations;
using Books.Contracts.Enums;

namespace Books.Contracts
{
    public class BookCreateDto
    {
        public int Id { get; set; }
        //[Required]
        //[MinLength(3, ErrorMessage = "Name must be at least 3 symbols.")]
        //[MaxLength(255, ErrorMessage = "Name must be less than 255 symbols.")]
        //public string Name { get; set; } = null!;
        //[MaxLength(255, ErrorMessage = "Description must be less than 255 symbols.")]
        //public string Description { get; set; } = null!;
        //public float? Price { get; set; }
        //public BookCommentStatus CommentStatus { get; set; }
        //public BookDownloadStatus DownloadStatus { get; set; }
        //public BookWritingStatus WritingStatus { get; set; }

        //public int CategoryId { get; set; }
        //public int AuthorId { get; set; }
        //public int BookAvatarImageId { get; set; }
        //public int CycleId { get; set; }
    }
}