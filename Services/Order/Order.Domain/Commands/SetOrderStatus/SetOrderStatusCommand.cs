using Order.Domain.Core.Commands;

namespace Order.Domain.Commands.SetOrderStatus
{
    public class SetOrderStatusCommand : Command
    {
        public SetOrderStatusCommand(Guid orderId, int orderStatusId)
        {
            this.orderId = orderId;
            this.orderStatusId = orderStatusId;
        }

        public Guid orderId { get; private set; }
        public int orderStatusId { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new SetOrderStatusCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
