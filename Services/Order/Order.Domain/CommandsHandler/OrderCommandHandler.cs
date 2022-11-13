using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Order.Domain.Commands.OrderCommand;
using Order.Domain.Core.Bus;

namespace Order.Domain.CommandsHandler
{
    public class OrderCommandHandler : CommandHandlers,
            IRequestHandler<OrderCreateCommand, bool>,
            IRequestHandler<OrderUpdateCommand, bool>,
            IRequestHandler<OrderDeleteCommand, bool>
    {
        private readonly ILogger<OrderCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IPublishEndpoint publishEndpoint;

        public OrderCommandHandler(IMediatorHandler bus,
                                   ILogger<OrderCommandHandler> logger,
                                   IMapper mapper,
                                   IPublishEndpoint publishEndpoint) : base(bus)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.publishEndpoint = publishEndpoint;
        }

        public Task<bool> Handle(OrderCreateCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid()) {
                logger.LogWarning("Dữ liệu không hợp lệ tại: OrderCommandHanler - CreateCommand");
                Task.FromResult(false);
            }
            // Nghiệp vụ xử lý
            OrderCheckoutEvent orderCheckout = new OrderCheckoutEvent() {
                userId = command.userId,
                price = 0,
                products = command.orderItemCommands
                            .Select(or => new OrderItemCheckoutEvent(or.productId, or.count))
                            .ToList(),
                checkOrchestration = true,
                CountCheckSaga = 0
            };
            publishEndpoint.Publish<OrderCheckoutEvent>(orderCheckout);


            return Task.FromResult(true);
        }

        public Task<bool> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
