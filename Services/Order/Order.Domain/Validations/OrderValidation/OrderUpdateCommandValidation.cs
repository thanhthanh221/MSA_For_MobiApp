using Order.Domain.Commands.OrderCommand;

namespace Order.Domain.Validations.OrderValidation
{
    public class OrderUpdateCommandValidation : OrderValidations<OrderUpdateCommand>
    {
        public OrderUpdateCommandValidation()
        {
            ValidateUserId();
            ValidateOrderItem();
            ValidateAddress();
        }
    }
}
