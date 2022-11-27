using MediatR;
using Microsoft.Extensions.Logging;
using Order.Domain.Interface;
using Order.Domain.Model;

namespace Order.Domain.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IOrderRepository orderRepository;
        private readonly ILogger<CreateOrderCommandHandler> logger;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork,
                                         IOrderRepository orderRepository,
                                         ILogger<CreateOrderCommandHandler> logger)
        {
            this.unitOfWork = unitOfWork;
            this.orderRepository = orderRepository;
            this.logger = logger;
        }

        public async Task<bool> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            // nếu check validation sai
            if(!command.IsValid())
            {
                logger.LogWarning("false check validation : Create Order Command...");
                return false;
            }

            // Create Order

            OrderAggregate order = new OrderAggregate(command.userId, command.userName);
            order.UpdateAddress(command.city,command.district,command.commune,command.street, command.detail);

            foreach (CreateOrderItemCommand orderIt in command.orderItemCommands) {
                order.AddOrderItem(
                    orderIt.productId, orderIt.productName, orderIt.image, orderIt.price, orderIt.count
                );
            }
            
            order.OrderBilling();

            logger.LogInformation($"Create Order: {order}");

            await orderRepository.CreateAsync(order);
            
            return await unitOfWork.SaveDbAsync();
        }
    }
}
