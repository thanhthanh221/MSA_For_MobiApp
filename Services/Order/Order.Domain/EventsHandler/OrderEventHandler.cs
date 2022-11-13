using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Order.Domain.Events.OrderEvent;

namespace Order.Domain.EventsHandler
{
    public class OrderEventHandler :
                INotificationHandler<OrderCreatedEvent>,
                INotificationHandler<OrderUpdatedEvent>,
                INotificationHandler<OrderDeletedEvent>
    {
        private readonly IPublishEndpoint publishEndpoint;

        public OrderEventHandler(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        public async Task Handle(OrderCreatedEvent message, CancellationToken cancellationToken)
        {

            // Topic Message RBMQ
            OrderCheckoutEvent orderCheckout = new OrderCheckoutEvent() {
                userId = message.userId,
                price = 0,
                // products = message.productPulishes
                //             .Select(or => new OrderItemCheckoutEvent(or.productId, or.count))
                //             .ToList(),
                checkOrchestration = true,
                CountCheckSaga = 0
            };
            await publishEndpoint.Publish<OrderCheckoutEvent>(orderCheckout);
        }

        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(OrderDeletedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
