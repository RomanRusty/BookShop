using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Core.Entities.Users
{
    [Table("Admins")]
    public class Admin : ApplicationUser
    {
        public virtual ICollection<GlobalNotification> GlobalNotifications { get; set; } = new HashSet<GlobalNotification>();

    }
}