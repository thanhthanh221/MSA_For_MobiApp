using MediatR;
using Order.Domain.Interface;
using Order.Domain.Model;

namespace Order.Domain.Commands.CancelOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, bool>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public CancelOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CancelOrderCommand command, CancellationToken cancellationToken)
        {
            OrderAggregate order = await orderRepository.GetByIdAsync(command.id);

            if(order is null)
            {
                return false;
            }

            order.SetCancellOrder();
            return await unitOfWork.SaveDbAsync();
        }
    }
}