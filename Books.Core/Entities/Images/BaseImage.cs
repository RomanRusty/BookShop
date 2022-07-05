using Books.Core.Entities.Base;

namespace Books.Core.Entities.Images
{
    public abstract class BaseImage : BaseEntity
    {
        public byte[] Data { get; set; } = null!;

    }
}