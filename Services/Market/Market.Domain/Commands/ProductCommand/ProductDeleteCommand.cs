using Market.Domain.Validations;
using Market.Domain.Validations.ProductValidation;

namespace Market.Domain.Commands.ProductCommand
{
    public class ProductDeleteCommand : ProductCommand
    {
        public ProductDeleteCommand(Guid Id)
        {
            this.Id = Id;
        }

        public override bool IsValid()
        {
            ValidationResult = new ProductDeleteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}