using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Books.Core.Entities.Base
{
    public abstract class BaseEntity:IIdEntity,IDateEntity,ISerializable
    {
        [Key]
        public int Id { get; set; }

        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt
        {
            get =>
                _createdAt ?? DateTime.Now;

            set => _createdAt = value;
        }
        [NotMapped]
        private DateTime? _createdAt = null;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}