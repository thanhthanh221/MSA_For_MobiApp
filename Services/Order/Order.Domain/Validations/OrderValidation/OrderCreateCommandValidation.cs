using Order.Domain.Commands.OrderCommand;

namespace Order.Domain.Validations.OrderValidation
{
    public class OrderCreateCommandValidation : OrderValidations<OrderCreateCommand>
    {
        public OrderCreateCommandValidation()
        {
            ValidateUserId();
            ValidateOrderItem();
            ValidateAddress();
        }
    }
}
