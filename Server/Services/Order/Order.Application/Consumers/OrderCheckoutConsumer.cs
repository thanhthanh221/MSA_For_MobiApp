using EventBus.Messages.Events;
using MassTransit;
using Order.Domain.Commands.CreateOrder;
using Order.Domain.Interface;
using Order.Domain.Model;

namespace Order.Application.Consumers
{
    public class OrderCheckoutConsumer : IConsumer<OrderCheckoutEvent>
    {
        private readonly MediatR.IMediator mediator;
        public OrderCheckoutConsumer(MediatR.IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Consume(ConsumeContext<OrderCheckoutEvent> context)
        {
            if (!context.Message.checkOrchestration) {

                if(context.Message.CountCheckSaga == 1) {
                    Console.WriteLine("Loi tai Market : " + context.Message.MessageError);
                    return;
                }
                else if(context.Message.CountCheckSaga == 2)
                {
                    return;
                }
            }

            // Tất cả đều không bug
            List<CreateOrderItemCommand> createOrderItems = new ();

            foreach (var orItem in context.Message.products) {
                CreateOrderItemCommand createOrderItem = new (
                    orItem.productId,
                    orItem.productName,
                    orItem.price,
                    orItem.count,
                    orItem.image
                );

                createOrderItems.Add(createOrderItem);
            }

            CreateOrderCommand createOrderCommand = new (
                Guid.NewGuid(),
                Guid.NewGuid().ToString().Substring(2,5),
                context.Message.city,
                context.Message.district,
                context.Message.commune,
                context.Message.street,
                context.Message.infomation,
                createOrderItems
            );
            


            Console.WriteLine(".......................Create Order Up to Database ......................");
            await mediator.Send(createOrderCommand);
        }
    }
}