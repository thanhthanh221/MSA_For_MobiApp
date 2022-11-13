using EventBus.Messages.Events;
using MassTransit;
using Order.Domain.Interface;

namespace Order.Application.Api.Consumers
{
    public class OrderCheckoutConsumer : IConsumer<OrderCheckoutEvent>
    {
        private readonly IOrderRepository orderRepository;

        public OrderCheckoutConsumer(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task Consume(ConsumeContext<OrderCheckoutEvent> context)
        {
            if (!context.Message.checkOrchestration) {

                if (context.Message.CountCheckSaga == 1) 
                {
                    Console.WriteLine("Loi tai Market : " + context.Message.checkOrchestration);

                }
            }

            
        }
    }
}