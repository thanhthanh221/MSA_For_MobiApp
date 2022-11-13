using Order.Domain.Core.Events;

namespace Order.Domain.Events.OrderEvent
{
    public class OrderDeletedEvent : Event
    {
        public OrderDeletedEvent(bool eventType) : base(eventType)
        {
        }
    }
}
