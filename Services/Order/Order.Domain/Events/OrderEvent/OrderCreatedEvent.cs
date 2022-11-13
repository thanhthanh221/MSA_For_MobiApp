using Order.Domain.Core.Events;
using Order.Domain.Model;

namespace Order.Domain.Events.OrderEvent
{
    public class ProductPulish
    {
        public ProductPulish(Guid productId, int count)
        {
            this.productId = productId;
            this.count = count;
        }

        public Guid productId { get; set; }
        public int count { get; set; }

    }
    public class OrderCreatedEvent : Event
    {
        public OrderCreatedEvent(bool eventType) : base(eventType)
        {
        }

        public Guid userId { get; private set; }
        public String description { get; private set; }
        public Boolean isDraft { get; private set; } 
        // Enum
        public OrderStatus orderStatus { get; private set; }
        public int orderStatusId { get; private set; }
        // Value Object
        public Address address { get; private set; }

        // 1 - N
        public List<OrderItem> orderItems { get; private set; }
    }

}
