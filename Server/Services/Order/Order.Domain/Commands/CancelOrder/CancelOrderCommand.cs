using Order.Domain.Core.Commands;

namespace Order.Domain.Commands.CancelOrder
{
    public class CancelOrderCommand : Command
    {
        public Guid id {get; private set;}
        public CancelOrderCommand()
        {
        }

        public CancelOrderCommand(Guid id)
        {
            this.id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new CancelOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}