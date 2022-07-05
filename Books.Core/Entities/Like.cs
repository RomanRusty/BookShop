using System.ComponentModel.DataAnnotations.Schema;
using Books.Core.Entities.Base;
using Books.Core.Entities.Users;

namespace Books.Core.Entities
{
    [Table("Likes")]
    public class Like:BaseEntity
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; } = null!;
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
    }
}