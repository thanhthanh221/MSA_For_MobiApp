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
        private readonly IUnitOfWork unitOfWork;


        public OrderCheckoutConsumer(MediatR.IMediator mediator,
                                     IUnitOfWork unitOfWork)
        {
            this.mediator = mediator;
            this.unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<OrderCheckoutEvent> context)
        {
            if (!context.Message.checkOrchestration) {

                if (context.Message.CountCheckSaga == 1) {
                    Console.WriteLine("Loi tai Market : " + context.Message.MessageError);
                    return;
                }
            }

            // Tất cả đều không bug
            List<CreateOrderItemCommand> createOrderItems = new List<CreateOrderItemCommand>();

            foreach (var orItem in context.Message.products) {
                CreateOrderItemCommand createOrderItem = new CreateOrderItemCommand(
                    orItem.productId,
                    orItem.productName,
                    orItem.price,
                    orItem.count,
                    orItem.image
                );

                createOrderItems.Add(createOrderItem);
            }

            // Address address = new Address(
            //     context.Message.city,
            //     context.Message.district,
            //     context.Message.commune,
            //     context.Message.street,
            //     context.Message.infomation
            // );
            // CreateOrderCommand createOrderCommand = new CreateOrderCommand(
            //     context.Message.userId,
            //     context.Message.userName,
            //     address,
            //     createOrderItems
            // );

            CreateOrderCommand createOrderCommand = new CreateOrderCommand(
                Guid.NewGuid(),
                Guid.NewGuid().ToString().Substring(2,5),
                "context.Message.city",
                "context.Message.district",
                "context.Message.commune",
                "context.Message.street",
                "context.Message.infomation",
                createOrderItems
            );
            


            Console.WriteLine(".......................Create Order Up to Database ......................");
            await mediator.Send(createOrderCommand);
        }
    }
}