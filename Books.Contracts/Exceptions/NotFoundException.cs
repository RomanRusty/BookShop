namespace Books.Contracts.Exceptions
{
    public class NotFoundException : Exception
    {
        public int EntityId { get; }
        public NotFoundException(string message, int entityId) : base(message)
        {
            EntityId = entityId;
        }

        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}
