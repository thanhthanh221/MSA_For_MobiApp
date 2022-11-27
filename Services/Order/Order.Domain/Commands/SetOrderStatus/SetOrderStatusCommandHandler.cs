using MediatR;
using Order.Domain.Interface;
using Order.Domain.Model;

namespace Order.Domain.Commands.SetOrderStatus
{
    // Cập nhật lại trạng thái đơn hàng
    public class SetOrderStatusCommandHandler : IRequestHandler<SetOrderStatusCommand, bool>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public SetOrderStatusCommandHandler(IOrderRepository orderRepository,IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(SetOrderStatusCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid())
            {
                return false;
            }
            OrderAggregate order = await orderRepository.GetByIdAsync(command.orderId);

            if(order is null)
            {
                return false;
            }
            return await unitOfWork.SaveDbAsync();
        }
    }
}











































































































































































