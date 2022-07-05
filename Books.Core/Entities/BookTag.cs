using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Books.Core.Entities.Base;

namespace Books.Core.Entities
{
    [Table("Tags")]
    public class BookTag:BaseEntity
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title must be at least 3 symbols.")]
        [MaxLength(255, ErrorMessage = "Title must be less than 255 symbols.")]
        public string Title { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}