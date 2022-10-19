using Market.Domain.Validations;

namespace Market.Domain.Commands
{
    public class DeleteProductCommand : ProductCommand
    {
        public DeleteProductCommand(Guid Id)
        {
            this.Id = Id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}