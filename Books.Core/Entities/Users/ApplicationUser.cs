using System.ComponentModel.DataAnnotations.Schema;
using Books.Core.Entities.Base;
using Books.Core.Entities.Images;
using Microsoft.AspNetCore.Identity;

namespace Books.Core.Entities.Users
{
    public abstract class ApplicationUser : IdentityUser<int>,IIdEntity,IDateEntity
    {
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt
        {
            get => _createdAt ?? DateTime.Now;
            set => _createdAt = value;
        }
        [NotMapped]
        private DateTime? _createdAt = null;

        public virtual UserAvatarImage? AvatarImage { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();



    }
}