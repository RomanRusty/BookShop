namespace Books.Core.Entities.Base
{
    public interface IDateEntity
    {
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}