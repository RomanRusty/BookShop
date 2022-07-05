using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Core.Entities.Users
{
    [Table("Readers")]
    public class Reader : ApplicationUser
    {
        public virtual ICollection<ReaderBook> ReaderBooks { get; set; } = new HashSet<ReaderBook>();
    }
}