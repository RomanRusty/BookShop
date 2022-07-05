using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Core.Entities.Users
{
    [Table("Authors")]
    public class Author : Reader
    {

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
        public virtual ICollection<Cycle> Cycles { get; set; } = new HashSet<Cycle>();

    }
}