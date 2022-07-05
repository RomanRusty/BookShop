using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Core.Entities.Images
{
    [Table("BookAvatarImages")]
    public class BookAvatarImage : BaseImage
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; } = null!;
    }
}