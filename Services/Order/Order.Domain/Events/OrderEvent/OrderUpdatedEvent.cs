using Order.Domain.Core.Events;

namespace Order.Domain.Events.OrderEvent
{
    public class OrderUpdatedEvent : Event
    {
        public OrderUpdatedEvent(bool eventType) : base(eventType)
        {
        }
    }
}
