using Order.Domain.Core.Commands;
using Order.Domain.Validations.OrderValidation;

namespace Order.Domain.Commands.OrderCommand
{
    public class OrderDeleteCommand : OrderCommands
    {
        public OrderDeleteCommand(Guid Id)
        {
            this.Id = Id;
        }

        public override bool IsValid()
        {
            // Check xem dữ liệu có hợp lệ không
            ValidationResult = new OrderDeleteCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
