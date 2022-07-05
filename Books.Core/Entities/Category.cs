using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Books.Core.Entities.Base;

namespace Books.Core.Entities
{
    [Table("Categories")]
    public class Category:BaseEntity
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 symbols.")]
        [MaxLength(255, ErrorMessage = "Name must be less than 255 symbols.")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}