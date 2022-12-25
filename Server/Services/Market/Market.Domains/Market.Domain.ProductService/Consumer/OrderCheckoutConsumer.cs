using EventBus.Messages.Events;
using MassTransit;

namespace Market.Domain.ProductService.Consumer
{
    public class OrderCheckoutConsumer : IConsumer<OrderCheckoutEvent>
    {
        public Task Consume(ConsumeContext<OrderCheckoutEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
