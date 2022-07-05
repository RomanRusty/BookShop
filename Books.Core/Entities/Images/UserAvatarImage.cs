using System.ComponentModel.DataAnnotations.Schema;
using Books.Core.Entities.Users;

namespace Books.Core.Entities.Images
{
    [Table("UserAvatarImages")]
    public class UserAvatarImage : BaseImage
    {
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
    }
}