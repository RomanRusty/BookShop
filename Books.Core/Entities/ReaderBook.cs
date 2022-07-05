using System.ComponentModel.DataAnnotations.Schema;
using Books.Core.Entities.Base;
using Books.Core.Entities.Enums;
using Books.Core.Entities.Users;

namespace Books.Core.Entities
{
    [Table("ReaderBooks")]
    public class ReaderBook:BaseEntity
    {
        public ReaderBookStatus Status { get; set; }

        public int ReaderId { get; set; }
        public virtual Reader Reader { get; set; } = null!;
        public int BookId { get; set; }
        public virtual Book Book { get; set; } = null!;
    }
}

