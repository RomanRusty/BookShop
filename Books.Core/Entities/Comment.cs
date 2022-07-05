using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Books.Core.Entities.Base;
using Books.Core.Entities.Users;

namespace Books.Core.Entities
{
    [Table("Comments")]
    public class Comment:BaseEntity
    {
        [Required]
        [MinLength(3, ErrorMessage = "Text must be at least 3 symbols.")]
        [MaxLength(255, ErrorMessage = "Text must be less than 255 symbols.")]
        public string Text { get; set; } = null!;

        public int BookId { get; set; }
        public virtual Book Book { get; set; } = null!;
        public int CreatorId { get; set; }
        public virtual ApplicationUser Creator { get; set; } = null!;
    }
}