using System.ComponentModel.DataAnnotations.Schema;
using Books.Core.Entities.Base;
using Books.Core.Entities.Users;

namespace Books.Core.Entities
{
    [Table("GlobalNotifications")]
    public class GlobalNotification : BaseEntity
    {
        public string Header { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; } = null!;
    }
}