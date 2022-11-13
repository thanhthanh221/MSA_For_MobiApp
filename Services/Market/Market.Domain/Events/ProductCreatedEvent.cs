namespace Market.Domain.Events
{
    public class ProductCreatedEvent
    {
        public Guid productId { get; set; }
        public int count { get; set; }
    }
}
