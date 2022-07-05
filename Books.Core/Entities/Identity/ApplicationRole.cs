using System.ComponentModel.DataAnnotations.Schema;
using Books.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace Books.Core.Entities.Identity
{
    public class ApplicationRole : IdentityRole<int>, IIdEntity, IDateEntity
    {
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt
        {
            get => _createdAt ?? DateTime.Now;

            set => _createdAt = value;
        }
        [NotMapped]
        private DateTime? _createdAt = null;

        public ApplicationRole()
        {
            
        }
        public ApplicationRole(string roleName):base(roleName)
        {
            
        }
    }
}